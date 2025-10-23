namespace MilesCarRental.Domain.Availability.Response
{
    /// <summary>
    /// Represents a rental agency that provides vehicles and branding information.
    /// </summary>
    public class Agency
    {
        /// <summary>Unique code that identifies the agency.</summary>
        public string AgencyCode { get; set; }

        /// <summary>Optional alternative or legacy code used internally.</summary>
        public object AgencyFakeCode { get; set; }

        /// <summary>Display name of the agency.</summary>
        public string AgencyName { get; set; }

        /// <summary>Branding images such as logos for different contexts.</summary>
        public Agencyimages AgencyImages { get; set; }

        /// <summary>Average customer rating of the agency.</summary>
        public float AgencyRating { get; set; }

        /// <summary>Account code used for billing or partner integrations.</summary>
        public string AccountCode { get; set; }

        /// <summary>Optional tour code reference.</summary>
        public object TourCode { get; set; }

        /// <summary>Optional partner code reference.</summary>
        public object PartnerCode { get; set; }
    }

}
