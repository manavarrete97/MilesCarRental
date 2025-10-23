using Microsoft.EntityFrameworkCore;
using MilesCarRental.Application.Abstractions;
using MilesCarRental.Domain.Vehicles;
using MilesCarRental.Infrastructure.Persistence;

namespace MilesCarRental.Infrastructure.Repositories
{
    /// <summary>
    /// EF Core implementation of IVehicleReadRepository.
    /// </summary>
    public sealed class VehicleReadRepository : IVehicleReadRepository
    {
        private readonly AppDbContext _db;

        public VehicleReadRepository(AppDbContext db)
        {
            _db = db;
        }

        /// <inheritdoc />
        public async Task<IReadOnlyList<(Vehicle vehicle, Inventory inventory)>>
            GetByPickupAsync(string pickupCity, string pickupCountry, CancellationToken ct)
        {
            var query =
                from i in _db.Inventories.AsNoTracking()
                join v in _db.Vehicles.AsNoTracking() on i.VehicleId equals v.Id
                where i.PickupCity == pickupCity && i.PickupCountry == pickupCountry
                select new { v, i };

            var rows = await query.ToListAsync(ct);

            return rows.Select(x => (x.v, x.i)).ToList();
        }
    }
}


