using System;
using System.Linq;
using FluentAssertions;
using MilesCarRental.Infrastructure.InMemory;
using Xunit;

namespace MilesCarRental.Tests;

public class AvailabilityMockMarketTests
{
    [Theory]
    [InlineData("CO", "CO", new[] { "Corolla", "RAV4" })]
    [InlineData("CO", "US", new[] { "Corolla", "Rio" })]
    [InlineData("US", "US", new[] { "Mustang", "Tahoe" })]
    [InlineData("FR", "DE", new string[0])]
    public void BuildRootobjectSample_Should_Filter_By_Market(string pickupIso, string customerIso, string[] expected)
    {
        var repo = new AvailabilityMockRepository();
        var pickup = DateTime.UtcNow;
        var ret = pickup.AddDays(2);

        var root = repo.BuildRootobjectSample(pickup, ret, "CityA", pickupIso, "CityB", pickupIso, customerIso);

        var names = root.Cars.Select(c => c.Vehicle.Name).ToArray();
        names.Should().BeEquivalentTo(expected);
    }
}
