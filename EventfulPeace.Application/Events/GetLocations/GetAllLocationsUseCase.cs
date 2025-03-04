using EventfulPeace.Application.Events.Dtos;
using EventfulPeace.Domain.Events.Entities;
using EventfulPeace.Domain.Events.Reads;
using MediatR;

namespace EventfulPeace.Application.Events.GetLocations;

public class GetAllLocationsUseCase(IEventReads reads)
    : IRequestHandler<GetAllLocationsRequest, LocationDto[]>
{
    public async Task<LocationDto[]> Handle(GetAllLocationsRequest req, CancellationToken ct)
    {
        Location[] locations = await reads.AllLocationsAsync(ct).ConfigureAwait(false);

        return [.. locations.Select(x => x.ToDto())];
    }
}
