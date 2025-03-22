using EventfulPeace.Application.Common;
using MediatR;

namespace EventfulPeace.Application.Events.UploadImage;

public class UploadEventImageUseCase(IStorageService storage)
    : IRequestHandler<UploadEventImageRequest, UploadEventImageDto>
{
    public async Task<UploadEventImageDto> Handle(UploadEventImageRequest req, CancellationToken ct)
    {
        var (Key, Url) = await storage.GetPresignedPostUrlAsync(
            folderPath: "images",
            name: req.EventName,
            contentType: req.ContentType,
            fileName: req.FileName
        );
        return new(
            GeneratedKey: Key,
            PresignedUrl: Url
        );
    }
}
