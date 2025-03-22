using MediatR;

namespace EventfulPeace.Application.Events.UploadImage;

public record UploadEventImageRequest(
    string EventName,
    string ContentType,
    string FileName
) : IRequest<UploadEventImageDto>;
