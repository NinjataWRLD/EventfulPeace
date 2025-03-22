namespace EventfulPeace.Web.Models;

public record FileModel(
    string PresignedUrl,
    string ContentType
);
