using Swashbuckle.AspNetCore.Filters;
using Res = MilesCarRental.Domain.Availability.Response;

namespace MilesCarRental.Api.SwaggerExamples;

public sealed class AvailabilityMockQueryExample : IExamplesProvider<IDictionary<string, object>>
{
    public IDictionary<string, object> GetExamples() => new Dictionary<string, object>
    {
        ["pickupDate"] = DateTime.UtcNow.Date.AddDays(1).ToString("O"),
        ["returnDate"] = DateTime.UtcNow.Date.AddDays(5).ToString("O"),
        ["pickupCity"] = "Medellín",
        ["pickupCountry"] = "CO",
        ["returnCity"] = "Bogotá",
        ["returnCountry"] = "CO",
        ["customerCountry"] = "CO",
    };
}

public sealed class AvailabilityMockUsQueryExample : IExamplesProvider<IDictionary<string, object>>
{
    public IDictionary<string, object> GetExamples() => new Dictionary<string, object>
    {
        ["pickupDate"] = DateTime.UtcNow.Date.AddDays(2).ToString("O"),
        ["returnDate"] = DateTime.UtcNow.Date.AddDays(6).ToString("O"),
        ["pickupCity"] = "Miami",
        ["pickupCountry"] = "US",
        ["returnCity"] = "Orlando",
        ["returnCountry"] = "US",
        ["customerCountry"] = "US",
    };
}
