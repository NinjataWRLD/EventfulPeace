namespace EventfulPeace.Application.Events.DownloadImage;

public record DownloadEventImageDto(
    string PresignedUrl,
    string ContentType
);
