using EventfulPeace.Domain.Common.Repositories;
using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Events;
using MediatR;

namespace EventfulPeace.Application.Events.Create;

public class CreateEventUseCase(IWrites<Event> writes, IUnitOfWork uow)
    : IRequestHandler<CreateEventRequest, EventId>
{
    public async Task<EventId> Handle(CreateEventRequest req, CancellationToken ct)
    {
        Event entity = Event.Create(
            name: req.Name,
            description: req.Description,
            occursAt: req.OccursAt,
            locationId: req.LocationId,
            creatorId: req.CreatorId
        );

        await writes.AddAsync(entity, ct).ConfigureAwait(false);
        await uow.SaveChangesAsync(ct).ConfigureAwait(false);

        return entity.Id;
    }
}