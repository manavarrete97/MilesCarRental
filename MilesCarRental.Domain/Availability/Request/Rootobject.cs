using MilesCarRental.Domain.Availability.Request;

namespace MilesCarRental.Domain.Availability.Request;

public class Rootobject
    {
        public string SearchKey { get; set; }
        public string IdSession { get; set; }
        public Pagination Pagination { get; set; }
        public Urldiscount[] UrlDiscount { get; set; }
    }
