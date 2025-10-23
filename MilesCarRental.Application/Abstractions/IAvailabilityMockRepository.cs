using System.Collections.Generic;
using MilesCarRental.Domain.Availability.Response;

namespace MilesCarRental.Application.Abstractions;

/// <summary>
/// Abstraction that provides a fully in-memory set of availability data used to mock the external provider.
/// Implementations should generate deterministic yet configurable responses for testing and development.
/// </summary>
public interface IAvailabilityMockRepository
{
    /// <summary>Agencies available in the mock dataset.</summary>
    IReadOnlyList<Agency> Agencies { get; }
    /// <summary>Branding images for agencies.</summary>
    IReadOnlyList<Agencyimages> Agencyimages { get; }
    /// <summary>Last generated cars for the current mock response.</summary>
    IReadOnlyList<Car> Cars { get; }
    IReadOnlyList<Currencyexchange> Currencyexchanges { get; }
    IReadOnlyList<Destinationlocation> Destinationlocations { get; }
    IReadOnlyList<Detaildiscount> Detaildiscounts { get; }
    IReadOnlyList<Discountcode> Discountcodes { get; }
    IReadOnlyList<Features> Features { get; }
    IReadOnlyList<Filterinformation> Filterinformations { get; }
    IReadOnlyList<Gallery> Galleries { get; }
    IReadOnlyList<Inclusion> Inclusions { get; }
    IReadOnlyList<Messageinformation> Messageinformations { get; }
    IReadOnlyList<Originlocation> Originlocations { get; }
    IReadOnlyList<Pagination> Paginations { get; }
    IReadOnlyList<Paymentdata> Paymentdatas { get; }
    IReadOnlyList<Phones> Phones { get; }
    IReadOnlyList<Phones1> Phones1 { get; }
    IReadOnlyList<Pickuplocation> Pickuplocations { get; }
    IReadOnlyList<Rate> Rates { get; }
    IReadOnlyList<Returnlocation> Returnlocations { get; }
    IReadOnlyList<Schedule> Schedules { get; }
    IReadOnlyList<Schedule1> Schedules1 { get; }
    IReadOnlyList<Sortinformation> Sortinformations { get; }
    IReadOnlyList<Tax> Taxes { get; }
    IReadOnlyList<Timerwatch> Timerwatches { get; }
    IReadOnlyList<Value> Values { get; }
    IReadOnlyList<Vehicle> Vehicles { get; }

    /// <summary>
    /// Builds a full availability root object using the given dates and location inputs.
    /// Dates must be in UTC. Cities are free text, and country codes must be ISO alpha-2 (e.g., CO, US).
    /// The resulting cars will respect market rules derived from pickup country and customer country.
    /// </summary>
    /// <param name="pickupDate">Pickup date (UTC).</param>
    /// <param name="returnDate">Return date (UTC).</param>
    /// <param name="pickupCity">Pickup city name.</param>
    /// <param name="pickupCountryIso">Pickup country ISO code.</param>
    /// <param name="returnCity">Return city name.</param>
    /// <param name="returnCountryIso">Return country ISO code.</param>
    /// <param name="customerCountryIso">Customer country ISO code.</param>
    /// <returns>A ready-to-serialize mock availability graph.</returns>
    Rootobject BuildRootobjectSample(
        System.DateTime? pickupDate = null,
        System.DateTime? returnDate = null,
        string? pickupCity = null,
        string? pickupCountryIso = null,
        string? returnCity = null,
        string? returnCountryIso = null,
        string? customerCountryIso = null);
}
