using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Common.ValueObjects;
using EventfulPeace.Domain.Events.Enums;

namespace EventfulPeace.Domain.Events.Reads;

public record EventsQuery(
    Pagination Pagination,
    UserId? CreatorId = null,
    UserId? ParticipantId = null,
    string? Name = null,
    EventSorting Sorting = EventSorting.FirstOccurs
);
