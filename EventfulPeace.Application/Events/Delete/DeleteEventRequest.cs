using EventfulPeace.Domain.Common.TypedIds;
using MediatR;

namespace EventfulPeace.Application.Events.Delete;

public record DeleteEventRequest(
    EventId Id,
    UserId CreatorId
) : IRequest;
