using System.Text.Json.Serialization;
using MilesCarRental.Domain.Serialization;

namespace MilesCarRental.Domain.Availability.Response
{
    /// <summary>
    /// Pickup office metadata (address, phones, schedule, codes).
    /// </summary>
    public class Pickuplocation
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Phones Phones { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Continent { get; set; }
        public string ContinentCode { get; set; }
        public string Type { get; set; }
        public Schedule Schedule { get; set; }
        public string FullSchedule { get; set; }
        public object[] Notes { get; set; }
        // Allow number or string; keep it as object to accept both without errors.
        public object Distance { get; set; }
    }

}
