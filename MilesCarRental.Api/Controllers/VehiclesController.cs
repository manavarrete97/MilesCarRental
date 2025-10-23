using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Application.Vehicles.Queries.GetAvailableVehicles;
using MilesCarRental.Application.Vehicles.Queries.GetAvailableVehicles.Models;
using Swashbuckle.AspNetCore.Filters;

namespace MilesCarRental.Api.Controllers;

[ApiController]
[Route("api/vehicles")]
public class VehiclesController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiclesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("availability")]
    [ProducesResponseType(typeof(GetAvailableVehiclesResult), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(MilesCarRental.Api.SwaggerExamples.GetAvailableVehiclesResultExample))]
    public async Task<IActionResult> GetAvailability(
        [FromQuery, DefaultValue("Medellín")] string pickupCity,
        [FromQuery, DefaultValue("Colombia")] string pickupCountry,
        [FromQuery, DefaultValue("Bogotá")] string returnCity,
        [FromQuery, DefaultValue("Colombia")] string returnCountry,
        [FromQuery, DefaultValue("Medellín")] string customerCity,
        [FromQuery, DefaultValue("Colombia")] string customerCountry,
        CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(pickupCity) || string.IsNullOrWhiteSpace(pickupCountry) ||
            string.IsNullOrWhiteSpace(returnCity) || string.IsNullOrWhiteSpace(returnCountry) ||
            string.IsNullOrWhiteSpace(customerCity) || string.IsNullOrWhiteSpace(customerCountry))
        {
            return BadRequest("Todos los parámetros son requeridos.");
        }

        var result = await _mediator.Send(new GetAvailableVehiclesQuery(
            pickupCity, pickupCountry, returnCity, returnCountry, customerCity, customerCountry
        ), ct);

        return Ok(result);
    }
}
