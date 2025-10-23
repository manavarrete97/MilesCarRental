namespace MilesCarRental.Domain.Availability.Response
{
    /// <summary>
    /// Discount codes and promotion identifiers attached to a fare.
    /// </summary>
    public class Discountcode
    {
        public string providerCode { get; set; }
        public string alternativeProviderCode { get; set; }
        public string name { get; set; }
        public string rateQualifier { get; set; }
        public string discountNumber { get; set; }
        public string tourNumber { get; set; }
        public string promotionCode { get; set; }
        public string motorCode { get; set; }
        public string code { get; set; }
        public string agencyCode { get; set; }
        public string bookingSource { get; set; }
        public string paymentType { get; set; }
    }

}
