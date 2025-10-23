namespace MilesCarRental.Domain.Availability.Response
{
    /// <summary>
    /// Pagination metadata for paged availability responses.
    /// </summary>
    public class Pagination
    {
        public int totalItems { get; set; }
        public int totalPage { get; set; }
        public int numberItemPerPage { get; set; }
        public int numberPage { get; set; }
    }

}
