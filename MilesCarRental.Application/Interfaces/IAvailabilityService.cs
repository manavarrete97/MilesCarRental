using System.Threading;
using System.Threading.Tasks;
using Req = MilesCarRental.Domain.Availability.Request;
using Res = MilesCarRental.Domain.Availability.Response;

namespace MilesCarRental.Application.Interfaces
{
    /// <summary>
    /// Contract to call the external MilesCar availability API.
    /// Implementations must serialize the request, perform the HTTP call and parse the response.
    /// </summary>
    public interface IAvailabilityService
    {
        /// <summary>
        /// Requests availability from the external API.
        /// </summary>
        /// <param name="request">Request payload to send.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Parsed response; never null.</returns>
        Task<Res.Rootobject> GetAvailabilityAsync(
            Req.Rootobject request,
            CancellationToken cancellationToken = default);
    }
}
