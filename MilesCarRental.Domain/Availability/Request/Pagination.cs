namespace MilesCarRental.Domain.Availability.Request;

public class Pagination
{
    public int NumberItemPerPage { get; set; }
    public int NumberPage { get; set; }
    public int TotalItems { get; set; }
    public int TotalPage { get; set; }
}