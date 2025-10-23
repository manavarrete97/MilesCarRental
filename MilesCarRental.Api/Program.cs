using System.Reflection;
using System.Text.Json;
using FluentValidation;
using MilesCarRental.Application;
using MilesCarRental.Application.Interfaces;
using MilesCarRental.Application.Services;
using MilesCarRental.Infrastructure;
using MilesCarRental.Infrastructure.External.Miles;
using MilesCarRental.Infrastructure.Persistence;
using MilesCarRental.Infrastructure.Persistence.Seed;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Extensions.Http;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Layers
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

// Bind external API options and wire infrastructure dependencies here (outermost layer)
builder.Services.Configure<MilesApiOptions>(builder.Configuration.GetSection("MilesApi"));

// Polly retry and timeout policies
var retryPolicy = HttpPolicyExtensions
    .HandleTransientHttpError()
    .OrResult(r => (int)r.StatusCode == 429)
    .WaitAndRetryAsync(new[] { TimeSpan.FromMilliseconds(200), TimeSpan.FromMilliseconds(500), TimeSpan.FromSeconds(1) });

var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(30));

// Use infrastructure implementation to honor DIP
builder.Services.AddHttpClient<IAvailabilityService, MilesApiAvailabilityService>((sp, client) =>
{
    var opts = sp.GetRequiredService<IOptions<MilesApiOptions>>().Value;
    client.BaseAddress = new Uri(opts.BaseUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("Accept-Language", "es-419,es;q=0.9,es-ES;q=0.8,en;q=0.7,en-GB;q=0.6,en-US;q=0.5");
    client.DefaultRequestHeaders.Add("Origin", "https://www.milescarrental.com");
    client.DefaultRequestHeaders.Add("Referer", "https://www.milescarrental.com/");
    client.DefaultRequestHeaders.Add("User-Agent", "MilesCarRental.API/1.0 (+.NET 8)");
})
.AddPolicyHandler(retryPolicy)
.AddPolicyHandler(timeoutPolicy);

// Health checks (self and external Miles API)
builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy())
    .AddUrlGroup(new Uri("https://apiengine.milescarrental.com/"), name: "miles-api");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MilesCarRental API",
        Version = "v1",
        Description = "API para disponibilidad y gestión de vehículos y localidades"
    });
    options.CustomSchemaIds(type => type.FullName?.Replace('+', '.'));

// XML comments for controllers and models
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    // Examples support
    options.ExampleFilters();
});

// Register Swagger examples
builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Global exception handler -> ProblemDetails style JSON
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var feature = context.Features.Get<IExceptionHandlerPathFeature>();
        var ex = feature?.Error;
        context.Response.ContentType = "application/json";

        int status = ex switch
        {
            ValidationException => StatusCodes.Status400BadRequest,
            HttpRequestException => StatusCodes.Status502BadGateway,
            _ => StatusCodes.Status500InternalServerError
        };
        context.Response.StatusCode = status;

        var payload = new
        {
            status,
            title = status switch
            {
                StatusCodes.Status400BadRequest => "Validation error",
                StatusCodes.Status502BadGateway => "Downstream error",
                _ => "Server error"
            },
            detail = ex?.Message
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(payload));
    });
});

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await DbSeeder.SeedAsync(db);
}

// Enable Swagger in all environments
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MilesCarRental API v1");
    // default RoutePrefix = "swagger" so UI is at /swagger
});

// Redirect root to /swagger for convenience
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.UseHttpsRedirection();

// Health endpoints
app.MapHealthChecks("/health");

app.MapControllers();
app.Run();
