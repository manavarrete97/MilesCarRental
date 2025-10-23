namespace MilesCarRental.Domain.Availability.Response
{
    /// <summary>
    /// Represents a currency conversion snapshot used to present monetary values in a specific currency.
    /// </summary>
    public class Currencyexchange
    {
        /// <summary>Base price in the selected currency.</summary>
        public float Price { get; set; }
        /// <summary>Daily price in the selected currency.</summary>
        public float PriceDaily { get; set; }
        /// <summary>ISO currency code (e.g., USD, COP).</summary>
        public string Currency { get; set; }
        /// <summary>Conversion rate applied to transform base currency to this currency.</summary>
        public float RateConvertion { get; set; }
        /// <summary>Drop fee expressed in the selected currency.</summary>
        public float DropFee { get; set; }
        /// <summary>Tax value expressed in the selected currency.</summary>
        public float TaxValue { get; set; }
        /// <summary>Raw conversion value used by the provider (string or number).</summary>
        public object CurrencyExchangeValue { get; set; }
    }

}
