using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MilesCarRental.Application.Interfaces;
using Req = MilesCarRental.Domain.Availability.Request;
using Res = MilesCarRental.Domain.Availability.Response;

namespace MilesCarRental.Application.Availability.Queries.GetAvailability
{
    /// <summary>
    /// Handles GetAvailabilityQuery by mapping the quickSearch token into the external API request and invoking the service.
    /// </summary>
    public sealed class GetAvailabilityHandler : IRequestHandler<GetAvailabilityQuery, Res.Rootobject>
    {
        private readonly IAvailabilityService _service;

        public GetAvailabilityHandler(IAvailabilityService service) => _service = service;

        /// <inheritdoc />
        public Task<Res.Rootobject> Handle(GetAvailabilityQuery request, CancellationToken ct)
        {
            var req = new Req.Rootobject
            {
                SearchKey = request.QuickSearch,
                IdSession = Guid.NewGuid().ToString(),
                Pagination = new Req.Pagination
                {
                    NumberItemPerPage = 20,
                    NumberPage = 1,
                    TotalItems = 0,
                    TotalPage = 0
                },
                UrlDiscount = Array.Empty<Req.Urldiscount>()
            };

            return _service.GetAvailabilityAsync(req, ct);
        }
    }
}
