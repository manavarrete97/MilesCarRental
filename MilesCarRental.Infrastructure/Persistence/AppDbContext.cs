using Microsoft.EntityFrameworkCore;
using MilesCarRental.Domain.Vehicles;
using MilesCarRental.Domain.Locations;

namespace MilesCarRental.Infrastructure.Persistence
{
    /// <summary>
    /// Entity Framework Core DbContext for MilesCarRental.
    /// Contains sets for Vehicles, Inventories, ReturnLocations and Locations used in examples and tests.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        /// <summary>Vehicles catalog.</summary>
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        /// <summary>Vehicle inventories with temporal availability per pickup location.</summary>
        public DbSet<Inventory> Inventories => Set<Inventory>();
        /// <summary>Return locations associated to vehicles.</summary>
        public DbSet<ReturnLocation> ReturnLocations => Set<ReturnLocation>();
        /// <summary>All locations used by the Vehicles endpoints.</summary>
        public DbSet<Location> Locations => Set<Location>();
    }
}
