namespace MilesCarRental.Domain.Availability.Response
{
    public class Vehicle
    {
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public int CategoryPosition { get; set; }
        public string CategoryIcon { get; set; }
        public object[] SubCategory { get; set; }
        public string Class { get; set; }
        public int ClassId { get; set; }
        public object ClassImage { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Group { get; set; }
        public int SmallBags { get; set; }
        public int LargeBags { get; set; }
        public int TotalBags { get; set; }
        public int Passengers { get; set; }
        public string TypeTransmission { get; set; }
        public bool AirConditioner { get; set; }
        public bool SimilarModel { get; set; }
        public bool ExclusiveModel { get; set; }
        public bool LimitedMileage { get; set; }
        public string ImageUrl { get; set; }
        public string ImageWeb { get; set; }
        public Gallery[] Gallery { get; set; }
    }

}
