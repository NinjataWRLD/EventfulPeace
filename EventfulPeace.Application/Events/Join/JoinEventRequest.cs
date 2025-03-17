using EventfulPeace.Domain.Common.TypedIds;
using MediatR;

namespace EventfulPeace.Application.Events.Join;

public record JoinEventRequest(
    EventId Id,
    UserId ParticipantId
) : IRequest;
