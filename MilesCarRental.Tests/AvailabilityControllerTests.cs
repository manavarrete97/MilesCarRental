using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Api.Controllers;
using MilesCarRental.Application.Availability.Queries.GetAvailability;
using MilesCarRental.Application.Availability.Queries.GetMockAvailability;
using Moq;
using Xunit;
using Res = MilesCarRental.Domain.Availability.Response;

namespace MilesCarRental.Tests;

public class AvailabilityControllerTests
{
    [Fact]
    public async Task Get_Should_Return_BadRequest_When_QuickSearch_Missing()
    {
        var mediator = new Mock<IMediator>();
        var controller = new AvailabilityController(mediator.Object);

        var result = await controller.Get("", CancellationToken.None);

        result.Result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async Task Get_Should_Return_Ok_When_Service_Ok()
    {
        var mediator = new Mock<IMediator>();
        mediator.Setup(m => m.Send(It.IsAny<GetAvailabilityQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Res.Rootobject { Cars = Array.Empty<Res.Car>() });

        var controller = new AvailabilityController(mediator.Object);
        var result = await controller.Get("token", CancellationToken.None);

        result.Result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task GetMock_Should_Validate_Dates()
    {
        var mediator = new Mock<IMediator>();
        var controller = new AvailabilityController(mediator.Object);

        var result = await controller.GetMock(null, null, null, null, null, null, null, CancellationToken.None);
        result.Result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async Task GetMock_Should_Return_Ok()
    {
        var mediator = new Mock<IMediator>();
        mediator.Setup(m => m.Send(It.IsAny<GetMockAvailabilityWithDatesQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Res.Rootobject { Cars = Array.Empty<Res.Car>() });

        var controller = new AvailabilityController(mediator.Object);
        var now = DateTime.UtcNow;

        var result = await controller.GetMock(now, now.AddDays(1), "Medellín", "CO", "Bogotá", "CO", "CO", CancellationToken.None);
        result.Result.Should().BeOfType<OkObjectResult>();
    }
}
