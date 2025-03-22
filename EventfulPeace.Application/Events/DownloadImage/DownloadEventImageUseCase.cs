using EventfulPeace.Application.Common;
using EventfulPeace.Application.Common.Exceptions;
using EventfulPeace.Domain.Events;
using EventfulPeace.Domain.Events.Reads;
using MediatR;

namespace EventfulPeace.Application.Events.DownloadImage;

public class DownloadEventImageUseCase(IEventReads reads, IStorageService storage)
    : IRequestHandler<DownloadEventImageRequest, DownloadEventImageDto>
{
    public async Task<DownloadEventImageDto> Handle(DownloadEventImageRequest req, CancellationToken ct)
    {
        Event e = await reads.SingleAsync(req.Id, track: false, ct).ConfigureAwait(false)
            ?? throw EventException.NotFound(req.Id);

        string url = await storage.GetPresignedGetUrlAsync(
            key: e.ImageKey,
            contentType: e.ImageContentType
        ).ConfigureAwait(false);

        return new(
            PresignedUrl: url,
            ContentType: e.ImageContentType
        );
    }
}
