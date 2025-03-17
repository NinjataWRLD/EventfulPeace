using EventfulPeace.Domain.Common.Repositories;
using EventfulPeace.Domain.Events.Writes;
using MediatR;

namespace EventfulPeace.Application.Events.Join;

public class JoinEventUseCase(IEventWrites writes, IUnitOfWork uow)
    : IRequestHandler<JoinEventRequest>
{
    public async Task Handle(JoinEventRequest req, CancellationToken ct)
    {
        await writes.JoinAsync(req.Id, req.ParticipantId, ct).ConfigureAwait(false);
        await uow.SaveChangesAsync(ct).ConfigureAwait(false);
    }
}
