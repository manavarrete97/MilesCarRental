using System.Text.Json.Serialization;

namespace MilesCarRental.Infrastructure.External.Miles.ProviderDtos;

// Provider-specific DTOs (subset), decoupled from domain
public sealed class AvailabilityResponseProvider
{
    [JsonPropertyName("cars")]
    public List<CarProvider> Cars { get; set; } = new();
}

public sealed class CarProvider
{
    [JsonPropertyName("pickupLocation")] public LocationProvider PickupLocation { get; set; }
    [JsonPropertyName("returnLocation")] public LocationProvider ReturnLocation { get; set; }
    [JsonPropertyName("vehicle")] public VehicleProvider Vehicle { get; set; }
    [JsonPropertyName("totalPrice")] public decimal TotalPrice { get; set; }
    [JsonPropertyName("currency")] public string Currency { get; set; }
    [JsonPropertyName("agency")] public AgencyProvider Agency { get; set; }
}

public sealed class LocationProvider
{
    [JsonPropertyName("code")] public string Code { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("city")] public string City { get; set; }
    [JsonPropertyName("country")] public string Country { get; set; }
    [JsonPropertyName("distance")] public object Distance { get; set; }
}

public sealed class VehicleProvider
{
    [JsonPropertyName("category")] public string Category { get; set; }
    [JsonPropertyName("class")] public string Class { get; set; }
    [JsonPropertyName("type")] public string Type { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("brand")] public string Brand { get; set; }
    [JsonPropertyName("passengers")] public int Passengers { get; set; }
}

public sealed class AgencyProvider
{
    [JsonPropertyName("agencyCode")] public string AgencyCode { get; set; }
    [JsonPropertyName("agencyName")] public string AgencyName { get; set; }
}
