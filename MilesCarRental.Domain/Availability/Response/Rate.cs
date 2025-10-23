namespace MilesCarRental.Domain.Availability.Response
{
    /// <summary>
    /// Rate metadata associated with a car option (code, period, time, etc.).
    /// </summary>
    public class Rate
    {
        public string rateId { get; set; }
        public string ratePeriod { get; set; }
        public string rateCategory { get; set; }
        public DateTime rateTime { get; set; }
        public string rateCode { get; set; }
    }

}
