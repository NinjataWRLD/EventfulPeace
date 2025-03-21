using EventfulPeace.Application.Common.Exceptions;
using EventfulPeace.Domain.Common.Repositories;
using EventfulPeace.Domain.Events;
using EventfulPeace.Domain.Events.Reads;
using EventfulPeace.Domain.Events.Writes;
using MediatR;

namespace EventfulPeace.Application.Events.Delete;

public class DeleteEventUseCase(IEventReads reads, IEventWrites writes, IUnitOfWork uow) 
    : IRequestHandler<DeleteEventRequest>
{
    public async Task Handle(DeleteEventRequest req, CancellationToken ct)
    {
        Event e = await reads.SingleAsync(req.Id, ct: ct).ConfigureAwait(false)
            ?? throw EventException.NotFound(req.Id);

        if (req.CreatorId != e.CreatorId)
            throw EventException.Unauthorized(req.Id, req.CreatorId);

        writes.Remove(e);
        await uow.SaveChangesAsync(ct).ConfigureAwait(false);
    }
}