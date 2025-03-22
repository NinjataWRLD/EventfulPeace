using EventfulPeace.Domain.Common.TypedIds;
using MediatR;

namespace EventfulPeace.Application.Events.DownloadImage;

public record DownloadEventImageRequest(
    EventId Id
) : IRequest<DownloadEventImageDto>;
