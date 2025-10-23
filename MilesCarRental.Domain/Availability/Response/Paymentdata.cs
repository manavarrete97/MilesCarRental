namespace MilesCarRental.Domain.Availability.Response
{
    public class Paymentdata
    {
        public string CurrencyPayment { get; set; }
        public float ValuePayment { get; set; }
        public float ValuePaymentWithCoupon { get; set; }
        public bool HasShowCVV { get; set; }
    }

}
