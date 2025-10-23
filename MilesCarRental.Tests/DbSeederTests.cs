using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MilesCarRental.Infrastructure.Persistence;
using MilesCarRental.Infrastructure.Persistence.Seed;
using Xunit;

namespace MilesCarRental.Tests;

public class DbSeederTests
{
    [Fact]
    public async Task SeedAsync_Should_Create_Initial_Data()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("seed-db")
            .Options;

        await using var db = new AppDbContext(options);
        await DbSeeder.SeedAsync(db);

        (await db.Locations.CountAsync()).Should().BeGreaterThan(0);
        (await db.Vehicles.CountAsync()).Should().BeGreaterThan(0);
        (await db.Inventories.CountAsync()).Should().BeGreaterThan(0);
    }
}
