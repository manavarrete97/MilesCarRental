using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Domain.Locations;
using MilesCarRental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MilesCarRental.Api.Controllers;

/// <summary>
/// Locations endpoints used to manage and query branch/office locations.
/// </summary>
[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    private readonly AppDbContext _db;

    public LocationsController(AppDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Returns every location.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Location>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Location>>> GetAll(CancellationToken ct)
    {
        var list = await _db.Locations.AsNoTracking().ToListAsync(ct);
        return Ok(list);
    }

    /// <summary>
    /// Creates a new location.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Location), StatusCodes.Status201Created)]
    public async Task<ActionResult<Location>> Create(
        [FromBody, DefaultValue(typeof(Location), "{ 'City':'Medellín', 'Country':'Colombia' }")] Location location,
        CancellationToken ct)
    {
        await _db.Locations.AddAsync(location, ct);
        await _db.SaveChangesAsync(ct);
        return CreatedAtAction(nameof(GetAll), new { id = location.Id }, location);
    }
}
