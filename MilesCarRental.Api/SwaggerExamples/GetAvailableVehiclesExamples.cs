using Swashbuckle.AspNetCore.Filters;
using MilesCarRental.Application.Vehicles.Queries.GetAvailableVehicles.Models;

namespace MilesCarRental.Api.SwaggerExamples;

public sealed class GetAvailableVehiclesResultExample : IExamplesProvider<GetAvailableVehiclesResult>
{
    public GetAvailableVehiclesResult GetExamples()
    {
        return new GetAvailableVehiclesResult(
            MarketCode: "Colombia-Colombia",
            Vehicles: new List<VehicleAvailabilityDto>
            {
                new(
                    Id: Guid.NewGuid().ToString(),
                    Brand: "Toyota",
                    Model: "Corolla",
                    Category: "Sedán",
                    Seats: 5,
                    Transmission: "Automática",
                    MarketCode: "Colombia-Colombia",
                    PickupCity: "Medellín",
                    PickupCountry: "Colombia",
                    AvailableFrom: DateTime.UtcNow.ToString("O"),
                    AvailableTo: DateTime.UtcNow.AddDays(7).ToString("O")
                )
            },
            PickupOptions: new List<LocationDto>
            {
                new(Guid.NewGuid().ToString(), "Medellín", "Colombia"),
                new(Guid.NewGuid().ToString(), "Bogotá", "Colombia")
            },
            ReturnOptions: new List<LocationDto>
            {
                new(Guid.NewGuid().ToString(), "Bogotá", "Colombia"),
                new(Guid.NewGuid().ToString(), "Medellín", "Colombia")
            }
        );
    }
}
