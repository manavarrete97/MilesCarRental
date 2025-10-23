namespace MilesCarRental.Domain.Availability.Response
{
    /// <summary>
    /// Represents a tax component applied to a car price in a specific currency.
    /// </summary>
    public class Tax
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Currency { get; set; }
        public bool PayementInRental { get; set; }
    }

}
