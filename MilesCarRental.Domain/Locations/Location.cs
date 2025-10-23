namespace MilesCarRental.Domain.Locations;

/// <summary>
/// Represents a geographic location (city and country) used for pickup and return options.
/// </summary>
public sealed class Location
{
    /// <summary>Unique identifier.</summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>City name.</summary>
    public string City { get; set; } = string.Empty;

    /// <summary>Country name.</summary>
    public string Country { get; set; } = string.Empty;
}
