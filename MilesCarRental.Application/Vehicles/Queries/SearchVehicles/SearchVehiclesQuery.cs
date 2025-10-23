using MediatR;
using Res = MilesCarRental.Domain.Availability.Response;

namespace MilesCarRental.Application.Vehicles.Queries.SearchVehicles
{
    public record SearchVehiclesQuery(string QuickSearch) : IRequest<Res.Rootobject>;
}
