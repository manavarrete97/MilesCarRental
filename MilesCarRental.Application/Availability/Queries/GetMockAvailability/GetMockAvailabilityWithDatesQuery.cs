using MediatR;
using Res = MilesCarRental.Domain.Availability.Response;

namespace MilesCarRental.Application.Availability.Queries.GetMockAvailability;

/// <summary>
/// Query to build a mock availability response using dates and full location context.
/// Country values must be ISO alpha-2.
/// </summary>
/// <param name="PickupDate">UTC pickup date.</param>
/// <param name="ReturnDate">UTC return date.</param>
/// <param name="PickupCity">Pickup city name.</param>
/// <param name="PickupCountryIso">Pickup country ISO code (e.g., CO, US).</param>
/// <param name="ReturnCity">Return city name.</param>
/// <param name="ReturnCountryIso">Return country ISO code.</param>
/// <param name="CustomerCountryIso">Customer country ISO code.</param>
public sealed record GetMockAvailabilityWithDatesQuery(
    DateTime PickupDate,
    DateTime ReturnDate,
    string PickupCity,
    string PickupCountryIso,
    string ReturnCity,
    string ReturnCountryIso,
    string CustomerCountryIso
) : IRequest<Res.Rootobject>;
