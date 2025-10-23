using Microsoft.EntityFrameworkCore;
using MilesCarRental.Application.Abstractions;
using MilesCarRental.Domain.Locations;
using MilesCarRental.Infrastructure.Persistence;

namespace MilesCarRental.Infrastructure.Repositories;

/// <summary>
/// EF Core implementation of ILocationReadRepository.
/// </summary>
public sealed class LocationReadRepository : ILocationReadRepository
{
    private readonly AppDbContext _db;

    public LocationReadRepository(AppDbContext db)
    {
        _db = db;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<Location>> GetAllAsync(CancellationToken ct)
    {
        return await _db.Locations.AsNoTracking().ToListAsync(ct);
    }

    /// <inheritdoc />
    public async Task<Location?> FindAsync(string city, string country, CancellationToken ct)
    {
        return await _db.Locations.AsNoTracking()
            .FirstOrDefaultAsync(x => x.City == city && x.Country == country, ct);
    }
}
