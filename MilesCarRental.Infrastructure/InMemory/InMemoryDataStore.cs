using System.Collections.Generic;
using MilesCarRental.Domain.Vehicles;

namespace MilesCarRental.Infrastructure.InMemory
{
    public sealed class InMemoryDataStore
    {
        public List<Vehicle> Vehicles { get; } = new();
        public List<Inventory> Inventories { get; } = new();
        public object Inventory { get; internal set; }
    }
}
