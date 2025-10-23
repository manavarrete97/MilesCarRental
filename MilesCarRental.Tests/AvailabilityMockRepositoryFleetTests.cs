using System;
using System.Linq;
using FluentAssertions;
using MilesCarRental.Infrastructure.InMemory;
using Xunit;

namespace MilesCarRental.Tests;

public class AvailabilityMockRepositoryFleetTests
{
    [Theory]
    [InlineData("CO","CO", new[] {"Corolla","RAV4"})]
    [InlineData("CO","US", new[] {"Corolla","Rio"})]
    [InlineData("US","US", new[] {"Mustang","Tahoe"})]
    [InlineData("FR","DE", new string[0])]
    public void Fleet_Should_Be_Filtered_By_Market(string pickupIso, string customerIso, string[] names)
    {
        var repo = new AvailabilityMockRepository();
        var pick = DateTime.UtcNow;
        var ret = pick.AddDays(2);

        var root = repo.BuildRootobjectSample(pick, ret, "city1", pickupIso, "city2", pickupIso, customerIso);

        root.Cars.Select(c => c.Vehicle.Name).Should().BeEquivalentTo(names);
    }
}
