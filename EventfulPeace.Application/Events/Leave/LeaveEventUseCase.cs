using EventfulPeace.Domain.Common.Repositories;
using EventfulPeace.Domain.Events.Writes;
using MediatR;

namespace EventfulPeace.Application.Events.Leave;

public class LeaveEventUseCase(IEventWrites writes, IUnitOfWork uow)
    : IRequestHandler<LeaveEventRequest>
{
    public async Task Handle(LeaveEventRequest req, CancellationToken ct)
    {
        await writes.LeaveAsync(req.Id, req.ParticipantId, ct).ConfigureAwait(false);
        await uow.SaveChangesAsync(ct).ConfigureAwait(false);
    }
}
