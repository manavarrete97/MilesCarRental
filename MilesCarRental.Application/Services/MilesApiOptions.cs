namespace MilesCarRental.Application.Services;

public class MilesApiOptions
{
    public string BaseUrl { get; set; } = string.Empty;
    public string AvailabilityPath { get; set; } = "Api/Car/CarApi/Availability";
}
