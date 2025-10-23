using MediatR;
using MilesCarRental.Application.Abstractions;
using MilesCarRental.Application.Vehicles.Queries.GetAvailableVehicles.Models;

namespace MilesCarRental.Application.Vehicles.Queries.GetAvailableVehicles;

/// <summary>
/// Handles GetAvailableVehiclesQuery by applying a simple market rule and composing DTOs from repositories.
/// </summary>
public sealed class GetAvailableVehiclesHandler : IRequestHandler<GetAvailableVehiclesQuery, GetAvailableVehiclesResult>
{
    private readonly IVehicleReadRepository _vehicles;
    private readonly ILocationReadRepository _locations;

    public GetAvailableVehiclesHandler(IVehicleReadRepository vehicles, ILocationReadRepository locations)
    {
        _vehicles = vehicles;
        _locations = locations;
    }

    /// <inheritdoc />
    public async Task<GetAvailableVehiclesResult> Handle(GetAvailableVehiclesQuery request, CancellationToken ct)
    {
        var marketCode = $"{request.PickupCountry}-{request.CustomerCountry}";

        var rows = await _vehicles.GetByPickupAsync(request.PickupCity, request.PickupCountry, ct);

        var vehicles = rows
            .Where(t => t.vehicle.IsActive && (string.IsNullOrWhiteSpace(t.vehicle.MarketCode) || t.vehicle.MarketCode == marketCode))
            .Select(t => new VehicleAvailabilityDto(
                t.vehicle.Id.ToString(),
                t.vehicle.Brand,
                t.vehicle.Model,
                t.vehicle.Category,
                t.vehicle.Seats,
                t.vehicle.Transmission,
                string.IsNullOrWhiteSpace(t.vehicle.MarketCode) ? marketCode : t.vehicle.MarketCode,
                t.inventory.PickupCity,
                t.inventory.PickupCountry,
                t.inventory.AvailableFrom.ToString("O"),
                t.inventory.AvailableTo.ToString("O")
            ))
            .ToList();

        var allLocations = await _locations.GetAllAsync(ct);
        var pickupOptions = allLocations.Where(l => l.Country == request.PickupCountry)
            .Select(l => new LocationDto(l.Id.ToString(), l.City, l.Country)).ToList();
        var returnOptions = allLocations
            .Where(l => l.Country == request.ReturnCountry)
            .Select(l => new LocationDto(l.Id.ToString(), l.City, l.Country)).ToList();

        return new GetAvailableVehiclesResult(marketCode, vehicles, pickupOptions, returnOptions);
    }
}
