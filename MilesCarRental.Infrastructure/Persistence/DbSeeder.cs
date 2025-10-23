using MilesCarRental.Infrastructure.Persistence;
using MilesCarRental.Domain.Vehicles;
using MilesCarRental.Domain.Locations;

namespace MilesCarRental.Infrastructure.Persistence.Seed
{
    /// <summary>
    /// Seeds demo data for EF Core InMemory scenarios used in handlers and tests.
    /// </summary>
    public static class DbSeeder
    {
        /// <summary>
        /// Ensures the database contains a minimal dataset for locations, vehicles and inventories.
        /// Operation is idempotent.
        /// </summary>
        public static async Task SeedAsync(AppDbContext db)
        {
            if (!db.Locations.Any())
            {
                await db.Locations.AddRangeAsync(
                    new Location { City = "Medellín", Country = "Colombia" },
                    new Location { City = "Bogotá", Country = "Colombia" },
                    new Location { City = "Miami", Country = "USA" },
                    new Location { City = "Orlando", Country = "USA" }
                );
            }

            if (!db.Vehicles.Any())
            {
                var v1 = new Vehicle
                {
                    Id = Guid.NewGuid(),
                    Brand = "Toyota",
                    Model = "Corolla",
                    Category = "Sedán",
                    Seats = 5,
                    Transmission = "Automática",
                    MarketCode = "Colombia-Colombia"
                };

                var v2 = new Vehicle
                {
                    Id = Guid.NewGuid(),
                    Brand = "Kia",
                    Model = "Rio",
                    Category = "Hatchback",
                    Seats = 5,
                    Transmission = "Manual",
                    MarketCode = "Colombia-USA"
                };

                var v3 = new Vehicle
                {
                    Id = Guid.NewGuid(),
                    Brand = "Chevrolet",
                    Model = "Onix",
                    Category = "Sedán",
                    Seats = 5,
                    Transmission = "Automática",
                    MarketCode = "USA-USA"
                };

                await db.Vehicles.AddRangeAsync(v1, v2, v3);

                await db.Inventories.AddRangeAsync(
                    new Inventory
                    {
                        Id = Guid.NewGuid(),
                        VehicleId = v1.Id,
                        PickupCity = "Medellín",
                        PickupCountry = "Colombia",
                        AvailableFrom = DateTime.UtcNow.Date,
                        AvailableTo = DateTime.UtcNow.Date.AddDays(7)
                    },
                    new Inventory
                    {
                        Id = Guid.NewGuid(),
                        VehicleId = v2.Id,
                        PickupCity = "Bogotá",
                        PickupCountry = "Colombia",
                        AvailableFrom = DateTime.UtcNow.Date.AddDays(1),
                        AvailableTo = DateTime.UtcNow.Date.AddDays(14)
                    },
                    new Inventory
                    {
                        Id = Guid.NewGuid(),
                        VehicleId = v3.Id,
                        PickupCity = "Miami",
                        PickupCountry = "USA",
                        AvailableFrom = DateTime.UtcNow.Date,
                        AvailableTo = DateTime.UtcNow.Date.AddDays(10)
                    }
                );
            }

            await db.SaveChangesAsync();
        }
    }
}
