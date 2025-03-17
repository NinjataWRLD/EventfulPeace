using EventfulPeace.Domain.Common.TypedIds;
using MediatR;

namespace EventfulPeace.Application.Events.Edit;

public record EditEventRequest(
    EventId Id,
    string Name,
    string Description,
    DateTime OccursAt,
    LocationId LocationId
) : IRequest;
