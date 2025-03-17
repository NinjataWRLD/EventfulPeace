using EventfulPeace.Domain.Common.TypedIds;
using MediatR;

namespace EventfulPeace.Application.Events.SetImagePath;

public record SetEventImagePathRequest(
    EventId Id,
    string Path,
    UserId CreatorId
) : IRequest;
