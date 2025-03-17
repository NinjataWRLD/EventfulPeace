using EventfulPeace.Application.Common.Exceptions;
using EventfulPeace.Domain.Common.Repositories;
using EventfulPeace.Domain.Events;
using EventfulPeace.Domain.Events.Reads;
using MediatR;

namespace EventfulPeace.Application.Events.Edit;

public class EditEventUseCase(IEventReads reads, IUnitOfWork uow)
    : IRequestHandler<EditEventRequest>
{
    public async Task Handle(EditEventRequest req, CancellationToken ct)
    {
        Event e = await reads.SingleAsync(req.Id, ct: ct).ConfigureAwait(false)
            ?? throw EventException.NotFound(req.Id);

        if (e.CreatorId != req.CreatorId)
            throw EventException.NotFound(req.Id);

       e.SetName(req.Name);
       e.SetDescription(req.Description);
       e.SetOccursAt(req.OccursAt);
       e.SetLocationId(req.LocationId);

        await uow.SaveChangesAsync(ct).ConfigureAwait(false);
    }
}