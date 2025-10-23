using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using MilesCarRental.Application.Interfaces;
using MilesCarRental.Application.Services; // for MilesApiOptions
using MilesCarRental.Infrastructure.External.Miles.Transformers;
using MilesCarRental.Infrastructure.External.Miles.ProviderDtos;
using AutoMapper;
using Req = MilesCarRental.Domain.Availability.Request;
using Res = MilesCarRental.Domain.Availability.Response;

namespace MilesCarRental.Infrastructure.External.Miles;

/// <summary>
/// Infrastructure implementation of IAvailabilityService that calls Miles external API.
/// </summary>
public sealed class MilesApiAvailabilityService : IAvailabilityService
{
    private readonly HttpClient _http;
    private readonly MilesApiOptions _opts;
    private readonly ILogger<MilesApiAvailabilityService> _logger;
    private readonly IMapper _mapper;

    private static readonly JsonSerializerOptions _json = new()
    {
        PropertyNamingPolicy = null,
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    private static readonly Meter Meter = new("MilesCarRental.Infrastructure.Availability");
    private static readonly Histogram<double> RequestDurationMs = Meter.CreateHistogram<double>(
        name: "availability_http_duration_ms",
        unit: "ms",
        description: "Duration of Miles availability HTTP requests in milliseconds");

    public MilesApiAvailabilityService(HttpClient http, IOptions<MilesApiOptions> opts, ILogger<MilesApiAvailabilityService> logger, IMapper mapper)
    {
        _http = http;
        _opts = opts.Value;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Res.Rootobject> GetAvailabilityAsync(
        Req.Rootobject request,
        CancellationToken cancellationToken = default)
    {
        var payload = BuildPayload(request);
        var body = JsonSerializer.Serialize(payload, _json);
        using var content = new StringContent(body, Encoding.UTF8, "application/json");

        var path = string.IsNullOrWhiteSpace(_opts.AvailabilityPath)
            ? "Api/Car/CarApi/Availability"
            : _opts.AvailabilityPath;

        // Log outbound request (sanitized + truncate)
        var safePayload = BuildSafeLogPayload(request);
        _logger.LogInformation("POST {Path} payload={Payload}", path, Truncate(JsonSerializer.Serialize(safePayload, _json), 1000));

        var sw = Stopwatch.StartNew();
        using var resp = await _http.PostAsync(path, content, cancellationToken);
        sw.Stop();
        RequestDurationMs.Record(sw.Elapsed.TotalMilliseconds);

        var raw = await resp.Content.ReadAsStringAsync(cancellationToken);

        // Log inbound response (truncate)
        _logger.LogInformation("RESP {Status} {Path} tookMs={Elapsed} body={Body}", (int)resp.StatusCode, path, sw.Elapsed.TotalMilliseconds, Truncate(raw, 2000));

        if (!resp.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"MilesCar API error {(int)resp.StatusCode}: {Truncate(raw, 1000)}");
        }

        var normalized = MilesAvailabilityJsonNormalizer.Normalize(raw);

        // Deserialize into provider DTOs then map to domain
        var provider = JsonSerializer.Deserialize<AvailabilityResponseProvider>(normalized, _json) ?? new AvailabilityResponseProvider();
        var domain = _mapper.Map<Res.Rootobject>(provider);
        return domain ?? new Res.Rootobject();
    }

    private static string Truncate(string? s, int max)
        => string.IsNullOrEmpty(s) ? string.Empty : s.Length <= max ? s : s[..max] + "...";

    private static object BuildSafeLogPayload(Req.Rootobject req)
    {
        string? Mask(string? v)
        {
            if (string.IsNullOrEmpty(v)) return v;
            var keep = Math.Min(4, v.Length);
            return new string('*', Math.Max(0, v.Length - keep)) + v[^keep..];
        }

        var discounts = (req?.UrlDiscount as System.Collections.IEnumerable)?
            .Cast<object>()
            .Select(d => new
            {
                code = Mask(TryGetString(d, "code") ?? TryGetString(d, "Code")),
                value = Mask(TryGetString(d, "value") ?? TryGetString(d, "Value"))
            })
            .ToArray() ?? Array.Empty<object>();

        return new
        {
            SearchKey = Mask(req?.SearchKey),
            idSession = Mask(req?.IdSession),
            Pagination = new
            {
                numberItemPerPage = TryGetInt(req?.Pagination, "numberItemPerPage") ?? TryGetInt(req?.Pagination, "NumberItemPerPage"),
                numberPage = TryGetInt(req?.Pagination, "numberPage") ?? TryGetInt(req?.Pagination, "NumberPage"),
                totalItems = TryGetInt(req?.Pagination, "totalItems") ?? TryGetInt(req?.Pagination, "TotalItems"),
                totalPage = TryGetInt(req?.Pagination, "totalPage") ?? TryGetInt(req?.Pagination, "TotalPage")
            },
            UrlDiscount = discounts
        };
    }

    private static int? TryGetInt(object? obj, string propertyName)
    {
        if (obj is null) return null;
        var pi = obj.GetType().GetProperty(propertyName);
        if (pi is null) return null;
        var val = pi.GetValue(obj);
        return val switch
        {
            null => null,
            int i => i,
            IConvertible c => Convert.ToInt32(c),
            _ => null
        };
    }

    private static string? TryGetString(object? obj, string propertyName)
    {
        if (obj is null) return null;
        var pi = obj.GetType().GetProperty(propertyName);
        return pi?.GetValue(obj)?.ToString();
    }

    private static object BuildPayload(Req.Rootobject request)
    {
        var paginationObj = request?.Pagination;
        var numberItemPerPage = TryGetInt(paginationObj, "numberItemPerPage")
                                ?? TryGetInt(paginationObj, "NumberItemPerPage")
                                ?? 10;
        var numberPage = TryGetInt(paginationObj, "numberPage")
                         ?? TryGetInt(paginationObj, "NumberPage")
                         ?? 1;
        var totalItems = TryGetInt(paginationObj, "totalItems")
                         ?? TryGetInt(paginationObj, "TotalItems")
                         ?? 0;
        var totalPage = TryGetInt(paginationObj, "totalPage")
                        ?? TryGetInt(paginationObj, "TotalPage")
                        ?? 0;

        var urlDiscount = (request?.UrlDiscount as System.Collections.IEnumerable)?
            .Cast<object>()
            .Select(d => new
            {
                code = TryGetString(d, "code") ?? TryGetString(d, "Code") ?? string.Empty,
                value = TryGetString(d, "value") ?? TryGetString(d, "Value") ?? string.Empty
            })
            .ToArray() ?? Array.Empty<object>();

        return new
        {
            request?.SearchKey,
            idSession = request?.IdSession ?? string.Empty,
            Pagination = new
            {
                numberItemPerPage,
                numberPage,
                totalItems,
                totalPage
            },
            UrlDiscount = urlDiscount
        };
    }
}
