using EventfulPeace.Domain.Common.ValueObjects;
using EventfulPeace.Domain.Events.Enums;
using MediatR;

namespace EventfulPeace.Application.Events.GetAllByLocation;

public record GetAllEventsByLocationRequest(
    Pagination Pagination,
    string? Name = null,
    EventSorting Sorting = EventSorting.FirstOccurs
) : IRequest<Dictionary<string, GetAllEventsByLocationDto[]>>;
