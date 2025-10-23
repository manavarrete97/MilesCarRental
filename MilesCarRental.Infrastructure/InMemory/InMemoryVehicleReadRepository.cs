using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MilesCarRental.Application.Abstractions;
using MilesCarRental.Domain.Vehicles;

namespace MilesCarRental.Infrastructure.InMemory
{
    public sealed class InMemoryVehicleReadRepository : IVehicleReadRepository
    {
        private readonly InMemoryDataStore _store;

        public InMemoryVehicleReadRepository(InMemoryDataStore store)
        {
            _store = store;
        }

        public Task<IReadOnlyList<(Vehicle vehicle, Inventory inventory)>>
            GetByPickupAsync(string pickupCity, string pickupCountry, CancellationToken ct)
        {
            // Si quieres respetar el ct, podrías cancelar aquí:
            // ct.ThrowIfCancellationRequested();

            var rows =
                from i in _store.Inventories
                join v in _store.Vehicles on i.VehicleId equals v.Id
                where i.PickupCity == pickupCity && i.PickupCountry == pickupCountry
                select (v, i);

            return Task.FromResult<IReadOnlyList<(Vehicle, Inventory)>>(rows.ToList());
        }
    }
}
