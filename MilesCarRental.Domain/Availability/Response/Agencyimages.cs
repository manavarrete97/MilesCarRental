namespace MilesCarRental.Domain.Availability.Response
{
    /// <summary>
    /// Represents the branding image set used by an agency in different contexts (web, airport, pin, etc.).
    /// </summary>
    public class Agencyimages
    {
        /// <summary>Default logo URL.</summary>
        public string Logo { get; set; }
        /// <summary>Airport-specific logo URL.</summary>
        public string LogoAirport { get; set; }
        /// <summary>Pin logo URL.</summary>
        public string LogoPin { get; set; }
        /// <summary>Airport pin logo URL.</summary>
        public string LogoPinAirport { get; set; }
        /// <summary>Logo without background URL.</summary>
        public string LogoNoBackground { get; set; }
    }

}
