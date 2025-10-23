using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Api.Controllers;
using MilesCarRental.Application.Availability.Queries.GetMockAvailability;
using Moq;
using Res = MilesCarRental.Domain.Availability.Response;
using Xunit;

namespace MilesCarRental.Tests;

public class AvailabilityControllerMockTests
{
    [Fact]
    public async Task GetMock_Should_Validate_Dates_And_Return_Ok()
    {
        // Arrange
        var mediator = new Mock<IMediator>();
        mediator
            .Setup(m => m.Send(It.IsAny<GetMockAvailabilityWithDatesQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Res.Rootobject { Cars = Array.Empty<Res.Car>() });

        var controller = new AvailabilityController(mediator.Object);
        var pickup = new DateTime(2025, 1, 15, 10, 0, 0, DateTimeKind.Utc);
        var ret = new DateTime(2025, 1, 20, 10, 0, 0, DateTimeKind.Utc);

        // Act
        var result = await controller.GetMock(pickup, ret, "Medellín", "CO", "Bogotá", "CO", "CO", CancellationToken.None);

        // Assert
        result.Result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task GetMock_Should_Return_BadRequest_When_Dates_Missing()
    {
        // Arrange
        var mediator = new Mock<IMediator>();
        var controller = new AvailabilityController(mediator.Object);

        // Act
        var result = await controller.GetMock(null, null, null, null, null, null, null, CancellationToken.None);

        // Assert
        result.Result.Should().BeOfType<BadRequestObjectResult>();
    }
}
