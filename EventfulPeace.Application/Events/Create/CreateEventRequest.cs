using EventfulPeace.Domain.Common.TypedIds;
using MediatR;

namespace EventfulPeace.Application.Events.Create;

public record CreateEventRequest(
    string Name,
    string Description,
    (string Key, string ContentType) Image,
    DateTime OccursAt,
    UserId CreatorId,
    LocationId LocationId
) : IRequest<EventId>;
