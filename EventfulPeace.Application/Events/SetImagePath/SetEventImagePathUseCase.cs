using EventfulPeace.Application.Common.Exceptions;
using EventfulPeace.Domain.Common.Repositories;
using EventfulPeace.Domain.Events;
using EventfulPeace.Domain.Events.Reads;
using MediatR;

namespace EventfulPeace.Application.Events.SetImagePath;

public class SetEventImagePathUseCase(IEventReads reads, IUnitOfWork uow)
    : IRequestHandler<SetEventImagePathRequest>
{
    public async Task Handle(SetEventImagePathRequest req, CancellationToken ct)
    {
        Event e = await reads.SingleAsync(req.Id, ct: ct).ConfigureAwait(false)
            ?? throw EventException.NotFound(req.Id);

        if (req.CreatorId != e.CreatorId)
            throw EventException.Unauthorized(req.Id, req.CreatorId);

        e.SetImagePath(req.Path);
        await uow.SaveChangesAsync(ct).ConfigureAwait(false);
    }
}
