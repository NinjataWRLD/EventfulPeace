namespace EventfulPeace.Application.Events.UploadImage;

public record UploadEventImageDto(
    string GeneratedKey,
    string PresignedUrl
);
