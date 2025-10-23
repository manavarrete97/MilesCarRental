using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MilesCarRental.Application.Vehicles.Queries.GetAvailableVehicles;
using MilesCarRental.Infrastructure.Repositories;
using MilesCarRental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MilesCarRental.Tests;

public class GetAvailableVehiclesHandlerTests
{
    [Fact]
    public async Task Should_Return_Market_Filtered_Vehicles()
    {
        // Arrange: InMemory EF context
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "testdb-vehicles")
            .Options;

        await using var db = new AppDbContext(options);

        // Seed minimal vehicle + inventory
        var vehicleId = Guid.NewGuid();
        db.Vehicles.Add(new MilesCarRental.Domain.Vehicles.Vehicle
        {
            Id = vehicleId,
            Brand = "Toyota",
            Model = "Corolla",
            MarketCode = "Colombia-Colombia"
        });
        db.Inventories.Add(new MilesCarRental.Domain.Vehicles.Inventory
        {
            Id = Guid.NewGuid(),
            VehicleId = vehicleId,
            PickupCity = "Medellín",
            PickupCountry = "Colombia",
            AvailableFrom = DateTime.UtcNow,
            AvailableTo = DateTime.UtcNow.AddDays(3)
        });
        await db.SaveChangesAsync();

        var vehicleRepo = new VehicleReadRepository(db);
        var locationsRepo = new LocationReadRepository(db);

        var handler = new GetAvailableVehiclesHandler(vehicleRepo, locationsRepo);

        // Act
        var result = await handler.Handle(new GetAvailableVehiclesQuery(
            PickupCity: "Medellín",
            PickupCountry: "Colombia",
            ReturnCity: "Bogotá",
            ReturnCountry: "Colombia",
            CustomerCity: "Medellín",
            CustomerCountry: "Colombia"
        ), CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.MarketCode.Should().Be("Colombia-Colombia");
        result.Vehicles.Should().NotBeEmpty();
    }
}
