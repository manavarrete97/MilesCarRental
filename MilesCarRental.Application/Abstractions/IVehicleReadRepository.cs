using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MilesCarRental.Domain.Vehicles;

namespace MilesCarRental.Application.Abstractions
{
    /// <summary>
    /// Read-only repository contract for Vehicles and their Inventory.
    /// </summary>
    public interface IVehicleReadRepository
    {
        /// <summary>
        /// Returns vehicles with their inventory filtered by pickup location.
        /// </summary>
        /// <param name="pickupCity">Pickup city.</param>
        /// <param name="pickupCountry">Pickup country.</param>
        /// <param name="ct">Cancellation token.</param>
        Task<IReadOnlyList<(Vehicle vehicle, Inventory inventory)>>
            GetByPickupAsync(string pickupCity, string pickupCountry, CancellationToken ct);
    }
}
