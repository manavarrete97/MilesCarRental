namespace MilesCarRental.Domain.Availability.Response
{
    public class Detaildiscount
    {
        public string name { get; set; }
        public string label { get; set; }
        public string currency { get; set; }
        public float value { get; set; }
        public float percent { get; set; }
        public bool show { get; set; }
        public object balanceDiscount { get; set; }
        public int order { get; set; }
        public string typeDetailDiscount { get; set; }
    }

}
