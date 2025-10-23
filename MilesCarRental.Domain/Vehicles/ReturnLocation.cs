namespace MilesCarRental.Domain.Vehicles;

public sealed class ReturnLocation
{
    public int Id { get; set; }
    public Guid InventoryId { get; set; }
    public string City { get; set; } = default!;
    public string Country { get; set; } = default!;
}
