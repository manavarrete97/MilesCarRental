using MediatR;
using MilesCarRental.Application.Abstractions;
using Res = MilesCarRental.Domain.Availability.Response;

namespace MilesCarRental.Application.Availability.Queries.GetMockAvailability;

public sealed class GetMockAvailabilityWithDatesHandler : IRequestHandler<GetMockAvailabilityWithDatesQuery, Res.Rootobject>
{
    private readonly IAvailabilityMockRepository _mock;

    public GetMockAvailabilityWithDatesHandler(IAvailabilityMockRepository mock)
    {
        _mock = mock;
    }

    public Task<Res.Rootobject> Handle(GetMockAvailabilityWithDatesQuery request, CancellationToken cancellationToken)
    {
        var sample = _mock.BuildRootobjectSample(
            request.PickupDate,
            request.ReturnDate,
            request.PickupCity,
            request.PickupCountryIso,
            request.ReturnCity,
            request.ReturnCountryIso,
            request.CustomerCountryIso);
        return Task.FromResult(sample);
    }
}
