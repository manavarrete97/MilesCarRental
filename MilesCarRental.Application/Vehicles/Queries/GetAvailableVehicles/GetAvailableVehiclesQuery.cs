using MediatR;
using MilesCarRental.Application.Vehicles.Queries.GetAvailableVehicles.Models;

namespace MilesCarRental.Application.Vehicles.Queries.GetAvailableVehicles;

/// <summary>
/// Query that retrieves available vehicles for a given trip and market context.
/// </summary>
/// <param name="PickupCity">Pickup city.</param>
/// <param name="PickupCountry">Pickup country.</param>
/// <param name="ReturnCity">Return city.</param>
/// <param name="ReturnCountry">Return country.</param>
/// <param name="CustomerCity">Customer city (to infer market).</param>
/// <param name="CustomerCountry">Customer country (to infer market).</param>
public sealed record GetAvailableVehiclesQuery(
    string PickupCity,
    string PickupCountry,
    string ReturnCity,
    string ReturnCountry,
    string CustomerCity,
    string CustomerCountry
) : IRequest<GetAvailableVehiclesResult>;
