using MediatR;
using Res = MilesCarRental.Domain.Availability.Response;

namespace MilesCarRental.Application.Availability.Queries.GetMockAvailability;

public sealed record GetMockAvailabilityQuery() : IRequest<Res.Rootobject>;
