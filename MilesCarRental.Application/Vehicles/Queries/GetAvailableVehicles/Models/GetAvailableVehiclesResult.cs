using System.Collections.Generic;

namespace MilesCarRental.Application.Vehicles.Queries.GetAvailableVehicles.Models;

public sealed record GetAvailableVehiclesResult(
    string MarketCode,
    IReadOnlyList<VehicleAvailabilityDto> Vehicles,
    IReadOnlyList<LocationDto> PickupOptions,
    IReadOnlyList<LocationDto> ReturnOptions
);

public sealed record VehicleAvailabilityDto(
    string Id,
    string Brand,
    string Model,
    string Category,
    int Seats,
    string Transmission,
    string MarketCode,
    string PickupCity,
    string PickupCountry,
    string AvailableFrom,
    string AvailableTo
);

public sealed record LocationDto(string Id, string City, string Country);
