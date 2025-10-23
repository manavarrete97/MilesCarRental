namespace MilesCarRental.Domain.Availability.Response
{
    public class Rootobject
    {
        public Pagination Pagination { get; set; }
        public object FilterApplied { get; set; }
        public Filterinformation[] FilterInformation { get; set; }
        public object SortApplied { get; set; }
        public Sortinformation[] SortInformation { get; set; }
        public string Method { get; set; }
        public Car[] Cars { get; set; }
        public bool HasToShowSoldOut { get; set; }
        public object Traveler { get; set; }
        public int Target { get; set; }
        public Timerwatch[] Timerwatch { get; set; }
        public Messageinformation[] MessageInformation { get; set; }
        public object LogRules { get; set; }
        public bool IsLandingPage { get; set; }
        public Originlocation OriginLocation { get; set; }
        public Destinationlocation DestinationLocation { get; set; }
        public string IdSession { get; set; }
        public string[] TargetApply { get; set; }
        public object RuleInformation { get; set; }
        public bool ShowLogRules { get; set; }
    }

}
