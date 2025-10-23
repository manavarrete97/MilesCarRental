using System;
using FluentAssertions;
using MilesCarRental.Infrastructure.InMemory;
using Xunit;

namespace MilesCarRental.Tests;

public class AvailabilityMockRepositoryPricingTests
{
    [Theory]
    [InlineData("CO","CO","COP",0.19)]
    [InlineData("CO","US","USD",0.08)]
    [InlineData("US","US","USD",0.08)]
    public void Pricing_Should_Match_Market(string pickupIso, string customerIso, string expectedCurrency, double expectedTax)
    {
        var repo = new AvailabilityMockRepository();
        var pick = DateTime.UtcNow;
        var ret = pick.AddDays(3);

        var root = repo.BuildRootobjectSample(pick, ret, "city1", pickupIso, "city2", pickupIso, customerIso);

        root.Cars.Should().NotBeNull();
        foreach (var car in root.Cars)
        {
            car.Currency.Should().Be(expectedCurrency);
            var total = car.BasePrice + car.TaxPrice;
            car.TotalPrice.Should().BeApproximately(total, 0.01f);

            var taxRate = (car.TaxPrice / car.BasePrice);
            taxRate.Should().BeApproximately((float)expectedTax, 0.0001f);
        }
    }
}
