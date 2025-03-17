using EventfulPeace.Application.Common.Dtos;
using EventfulPeace.Application.Common.Exceptions;
using EventfulPeace.Application.Events.GetSingle;
using EventfulPeace.Domain.Events;
using EventfulPeace.Domain.Events.Reads;
using EventfulPeace.Domain.Users;
using EventfulPeace.Domain.Users.Reads;
using MediatR;

namespace EventfulPeace.Application.Events.GetSingle;

public class GetSingleEventUseCase(IEventReads eventReads, IUserReads userReads)
    : IRequestHandler<GetSingleEventRequest, GetSingleEventDto>
{
    public async Task<GetSingleEventDto> Handle(GetSingleEventRequest req, CancellationToken ct)
    {
        Event entity = await eventReads.SingleAsync(req.Id, track: false, ct: ct).ConfigureAwait(false)
            ?? throw EventException.NotFound(req.Id);

        User user = await userReads.SingleAsync(entity.CreatorId, track: false, ct).ConfigureAwait(false)
            ?? throw UserException.NotFound(entity.CreatorId);

        return entity.ToDto(user.ToDto(), new ImageDto() { Path = entity.ImagePath });
    }
}