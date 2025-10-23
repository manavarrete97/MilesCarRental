// Application/Vehicles/Queries/SearchVehicles/SearchVehiclesHandler.cs
using MediatR;
using MilesCarRental.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Req = MilesCarRental.Domain.Availability.Request;
using Res = MilesCarRental.Domain.Availability.Response;

namespace MilesCarRental.Application.Vehicles.Queries.SearchVehicles
{
    public sealed class SearchVehiclesHandler : IRequestHandler<SearchVehiclesQuery, Res.Rootobject>
    {
        private readonly IAvailabilityService _service;

        public SearchVehiclesHandler(IAvailabilityService service)
        {
            _service = service;
        }

        public Task<Res.Rootobject> Handle(SearchVehiclesQuery request, CancellationToken ct)
        {
            var req = new Req.Rootobject
            {
                SearchKey = request.QuickSearch,
                IdSession = Guid.NewGuid().ToString(),
                Pagination = new Req.Pagination { NumberItemPerPage = 20, NumberPage = 1 },
                UrlDiscount = Array.Empty<Req.Urldiscount>()
            };
            return _service.GetAvailabilityAsync(req, ct);
        }
    }
}
