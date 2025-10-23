using System;
using FluentAssertions;
using MilesCarRental.Infrastructure.InMemory;
using Xunit;

namespace MilesCarRental.Tests;

public class AvailabilityMockRepositoryTests
{
    [Fact]
    public void BuildRootobjectSample_Should_Set_Pickup_And_Return_Dates()
    {
        // Arrange
        var repo = new AvailabilityMockRepository();
        var pickup = new DateTime(2025, 1, 15, 10, 0, 0, DateTimeKind.Utc);
        var @return = new DateTime(2025, 1, 20, 10, 0, 0, DateTimeKind.Utc);

        // Act
        var result = repo.BuildRootobjectSample(pickup, @return);

        // Assert
        result.Cars.Should().NotBeNull();
        result.Cars.Should().HaveCountGreaterThan(0);
        foreach (var car in result.Cars)
        {
            car.PickupDateTime.Should().Be(pickup);
            car.ReturnDateTime.Should().Be(@return);
            car.RentalDuration.Should().Be((int)Math.Ceiling((@return - pickup).TotalDays));
        }
    }
}
