using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilesCarRental.Domain.Vehicles;
using MilesCarRental.Infrastructure.Persistence;

namespace MilesCarRental.Api.Controllers;

[ApiController]
[Route("api/manage/vehicles")]
public class ManageVehiclesController : ControllerBase
{
    private readonly AppDbContext _db;

    public ManageVehiclesController(AppDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Lista todos los vehículos gestionables.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Vehicle>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetAll(CancellationToken ct)
    {
        var list = await _db.Vehicles.AsNoTracking().ToListAsync(ct);
        return Ok(list);
    }

    /// <summary>
    /// Crea un nuevo vehículo.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Vehicle), StatusCodes.Status201Created)]
    public async Task<ActionResult<Vehicle>> Create(Vehicle vehicle, CancellationToken ct)
    {
        await _db.Vehicles.AddAsync(vehicle, ct);
        await _db.SaveChangesAsync(ct);
        return CreatedAtAction(nameof(GetAll), new { id = vehicle.Id }, vehicle);
    }
}
