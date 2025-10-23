using MediatR;
using MilesCarRental.Application.Abstractions;
using Res = MilesCarRental.Domain.Availability.Response;

namespace MilesCarRental.Application.Availability.Queries.GetMockAvailability;

public sealed class GetMockAvailabilityHandler : IRequestHandler<GetMockAvailabilityQuery, Res.Rootobject>
{
    private readonly IAvailabilityMockRepository _mock;

    public GetMockAvailabilityHandler(IAvailabilityMockRepository mock)
    {
        _mock = mock;
    }

    public Task<Res.Rootobject> Handle(GetMockAvailabilityQuery request, CancellationToken cancellationToken)
    {
        var sample = _mock.BuildRootobjectSample();
        return Task.FromResult(sample);
    }
}
