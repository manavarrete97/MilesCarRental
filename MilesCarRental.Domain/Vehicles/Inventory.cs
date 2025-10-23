namespace MilesCarRental.Domain.Vehicles
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }

        // Ejemplo de datos para búsquedas
        public string PickupCity { get; set; } = string.Empty;
        public string PickupCountry { get; set; } = string.Empty;
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }

        // Relación con Vehicle
        public Vehicle? Vehicle { get; set; }
    }
}
