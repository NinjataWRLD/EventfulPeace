using EventfulPeace.Domain.Common.TypedIds;
using MediatR;

namespace EventfulPeace.Application.Events.Leave;

public record LeaveEventRequest(
    EventId Id,
    UserId ParticipantId
) : IRequest;
