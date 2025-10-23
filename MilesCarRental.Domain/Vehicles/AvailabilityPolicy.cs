namespace MilesCarRental.Domain.Vehicles;

public static class AvailabilityPolicy
{
    // Política simple: Market = $"{pickupCountry}-{customerCountry}"
    public static string Resolve(string pickupCountryIso2, string customerCountryIso2)
        => $"{pickupCountryIso2.ToUpperInvariant()}-{customerCountryIso2.ToUpperInvariant()}";
}
