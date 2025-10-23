using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MilesCarRental.Domain.Locations;

namespace MilesCarRental.Application.Abstractions;

/// <summary>
/// Read repository for location entities.
/// </summary>
public interface ILocationReadRepository
{
    /// <summary>Returns all locations.</summary>
    Task<IReadOnlyList<Location>> GetAllAsync(CancellationToken ct);
    /// <summary>Find a location by city and country name.</summary>
    Task<Location?> FindAsync(string city, string country, CancellationToken ct);
}
