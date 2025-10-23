namespace MilesCarRental.Domain.Availability.Response
{
    public class Inclusion
    {
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int CategoryPosition { get; set; }
        public string CategoryIcon { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Additional { get; set; }
        public string Code { get; set; }
        public bool MinInsurance { get; set; }
        public bool ShowMobile { get; set; }
        public int Position { get; set; }
        public object Value { get; set; }
        public bool ShowInclusion { get; set; }
        public bool IsFreeInclusion { get; set; }
    }

}
