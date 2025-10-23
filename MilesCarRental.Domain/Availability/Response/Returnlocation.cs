using System.Text.Json.Serialization;
using MilesCarRental.Domain.Serialization;

namespace MilesCarRental.Domain.Availability.Response
{
    /// <summary>
    /// Return office metadata (address, phones, schedule, codes).
    /// </summary>
    public class Returnlocation
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Phones1 Phones { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Continent { get; set; }
        public string ContinentCode { get; set; }
        public string Type { get; set; }
        public Schedule1 Schedule { get; set; }
        public string FullSchedule { get; set; }
        public object[] Notes { get; set; }
        public object Distance { get; set; }
    }

}
