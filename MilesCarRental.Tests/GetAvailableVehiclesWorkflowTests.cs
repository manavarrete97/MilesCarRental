using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MilesCarRental.Application.Vehicles.Queries.GetAvailableVehicles;
using MilesCarRental.Infrastructure.Persistence;
using MilesCarRental.Infrastructure.Repositories;
using Xunit;

namespace MilesCarRental.Tests;

public class GetAvailableVehiclesWorkflowTests
{
    [Fact]
    public async Task Full_Workflow_Should_Return_Data()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("workflow-db")
            .Options;

        await using var db = new AppDbContext(options);
        var vehicleRepo = new VehicleReadRepository(db);
        var locationRepo = new LocationReadRepository(db);

        var handler = new GetAvailableVehiclesHandler(vehicleRepo, locationRepo);

        var result = await handler.Handle(new GetAvailableVehiclesQuery(
            PickupCity: "Medellín",
            PickupCountry: "Colombia",
            ReturnCity: "Bogotá",
            ReturnCountry: "Colombia",
            CustomerCity: "Medellín",
            CustomerCountry: "Colombia"
        ), CancellationToken.None);

        result.Vehicles.Should().NotBeNull();
    }
}
