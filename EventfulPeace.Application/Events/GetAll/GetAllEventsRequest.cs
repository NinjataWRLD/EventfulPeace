using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Common.ValueObjects;
using EventfulPeace.Domain.Events.Enums;
using MediatR;

namespace EventfulPeace.Application.Events.GetAll;

public record GetAllEventsRequest(
    Pagination Pagination,
    UserId? CreatorId = null,
    UserId? ParticipantId = null,
    string? Name = null,
    EventSorting Sorting = EventSorting.FirstOccurs
) : IRequest<Result<GetAllEventsDto>>;
