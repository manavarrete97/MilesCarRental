namespace MilesCarRental.Domain.Availability.Response
{
    /// <summary>
    /// Performance metrics for the availability search collected by the provider.
    /// </summary>
    public class Timerwatch
    {
        public string name { get; set; }
        public string time { get; set; }
        public string provider { get; set; }
        public int typeTime { get; set; }
    }

}
