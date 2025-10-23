namespace MilesCarRental.Domain.Vehicles;

public sealed class Vehicle
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public string Category { get; set; } = "Sedan";
    public int Seats { get; set; } = 5;
    public string Transmission { get; set; } = "AT";
    public string MarketCode { get; set; } = default!;
    public bool IsActive { get; set; } = true;
}
