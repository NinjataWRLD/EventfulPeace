using EventfulPeace.Domain.Common.TypedIds;
using MediatR;

namespace EventfulPeace.Application.Events.GetSingle;

public record GetSingleEventRequest(
    EventId Id
) : IRequest<GetSingleEventDto>;
