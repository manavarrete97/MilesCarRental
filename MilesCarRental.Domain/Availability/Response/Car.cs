namespace MilesCarRental.Domain.Availability.Response
{
    /// <summary>
    /// Represents a rentable car option returned by the availability search, including pricing, locations and vehicle details.
    /// </summary>
    public class Car
    {
        public bool SoldOut { get; set; }
        /// <summary>Provider item code for the car option.</summary>
        public string ItemCode { get; set; }
        /// <summary>Total price at destination currency (may be numeric or complex).</summary>
        public object PriceDestination { get; set; }
        /// <summary>Owning agency information.</summary>
        public Agency Agency { get; set; }
        /// <summary>Fare and display features applied to the option.</summary>
        public Features Features { get; set; }
        /// <summary>Pickup office information.</summary>
        public Pickuplocation PickupLocation { get; set; }
        /// <summary>Return office information.</summary>
        public Returnlocation ReturnLocation { get; set; }
        /// <summary>Pickup date/time (UTC).</summary>
        public DateTime PickupDateTime { get; set; }
        /// <summary>Return date/time (UTC).</summary>
        public DateTime ReturnDateTime { get; set; }
        /// <summary>Vehicle attributes (brand, category, capacity, etc.).</summary>
        public Vehicle Vehicle { get; set; }
        public string PaymentType { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Discountcode DiscountCode { get; set; }
        public float BasePrice { get; set; }
        public float Subtotal { get; set; }
        public float BasePriceStrikeSpecial { get; set; }
        public float TotalPriceStrikeSpecial { get; set; }
        public object FarePaymentName { get; set; }
        public float BasePriceWithDiscount { get; set; }
        public float BasePriceWithCoupon { get; set; }
        public float TotalPrice { get; set; }
        public float TotalPriceWithCoupon { get; set; }
        public float TaxPrice { get; set; }
        public float RateConvertion { get; set; }
        public float RateCurrency { get; set; }
        public float RateBasePrice { get; set; }
        public float RealBasePrice { get; set; }
        public float RealTotalPrice { get; set; }
        public object BasePriceExchangeBase { get; set; }
        public object TotalPriceExchangeBase { get; set; }
        public Currencyexchange[] CurrencyExchange { get; set; }
        public string Currency { get; set; }
        public Tax[] Taxes { get; set; }
        public int RentalDuration { get; set; }
        public int FormatPrecision { get; set; }
        public float BasePriceDaily { get; set; }
        public float TotalPriceDaily { get; set; }
        public float BasePriceStrike { get; set; }
        public float TotalPriceStrike { get; set; }
        public float TaxPriceStrike { get; set; }
        public float BasePriceDailyStrike { get; set; }
        public float TotalPriceDailyStrike { get; set; }
        public float TaxPriceDailyStrike { get; set; }
        public float StrikeDiscount { get; set; }
        public float StrikeDiscountShow { get; set; }
        public float StrikeDiscountValue { get; set; }
        public float StrikeDiscountTotalValue { get; set; }
        public string ProviderCode { get; set; }
        public float Discount { get; set; }
        public float DiscountValue { get; set; }
        public float DiscountIOF { get; set; }
        public float DiscountCoupon { get; set; }
        public float TotalDiscountValue { get; set; }
        public float Markup { get; set; }
        public Rate Rate { get; set; }
        public string VehicleTypeOwner { get; set; }
        public Inclusion[] Inclusions { get; set; }
        public object[] PaymentAvailable { get; set; }
        public object[] ExtrasCar { get; set; }
        public object[] ExtrasFare { get; set; }
        public object[] Equipment { get; set; }
        public object[] Comments { get; set; }
        public Detaildiscount[] DetailDiscount { get; set; }
        public object ChangePrice { get; set; }
        public Paymentdata PaymentData { get; set; }
    }

}
