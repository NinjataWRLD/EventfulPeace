using EventfulPeace.Domain.Common.TypedIds;
using MediatR;

namespace EventfulPeace.Application.Events.Create;

public record CreateEventRequest(
    string Name,
    string Description,
    DateTime OccursAt,
    UserId CreatorId,
    LocationId LocationId
) : IRequest<EventId>;
