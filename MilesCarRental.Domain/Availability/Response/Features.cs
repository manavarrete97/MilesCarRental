namespace MilesCarRental.Domain.Availability.Response
{
    /// <summary>
    /// Fare attributes and flags that influence how the option is displayed and sold.
    /// </summary>
    public class Features
    {
        public string FareOrigin { get; set; }
        public string FareDestination { get; set; }
        public object FareTemplateMessage { get; set; }
        public string FareType { get; set; }
        public bool FareMobile { get; set; }
        public bool FareDisplayAvailability { get; set; }
        public bool FarePackage { get; set; }
        public bool FareCompareInDetail { get; set; }
        public bool FareInsurance { get; set; }
        public string FareTemplate { get; set; }
        public bool FirstPosition { get; set; }
        public bool SpecialRate { get; set; }
        public bool RecommendedRate { get; set; }
        public bool AllInclusiveRate { get; set; }
        public bool DollarDiamond { get; set; }
        public bool ThriftySapphire { get; set; }
        public bool AlamoMaxPromo { get; set; }
        public bool AlamoPromotion { get; set; }
        public bool OneFreeUpgrade { get; set; }
        public bool TwoFreeUpgrade { get; set; }
        public bool DriverUnder25 { get; set; }
        public bool IofBrasil { get; set; }
        public bool AvisBudgetBookingDiscount { get; set; }
        public bool UseLoyaltyCoupon { get; set; }
        public bool UseCancellationCoupon { get; set; }
        public bool IsWarningMarket { get; set; }
        public bool DoesApplyCustomerRetention { get; set; }
        public bool DealOfDay { get; set; }
        public bool UseUrlDiscount { get; set; }
        public bool IsFreeCancellation { get; set; }
        public bool IsEnableCoupon { get; set; }
        public bool IsSpecialOffer { get; set; }
        public bool IsBestValue { get; set; }
        public bool IsRecommended { get; set; }
        public bool IsMostRented { get; set; }
        public string FareInsuranceTemplate { get; set; }
        public bool IsFreeCarUpgrade { get; set; }
    }

}
