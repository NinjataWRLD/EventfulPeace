using System.Net.Http.Headers;

namespace EventfulPeace.Web.Extensions;

public static class FileExtensions
{
    public static async Task<bool> UploadFileAsync(this HttpClient client, IFormFile file, string url, CancellationToken ct = default)
    {
        using var fileStream = file.OpenReadStream();
        using var content = new StreamContent(fileStream);

        content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
        content.Headers.Add("x-amz-meta-file-name", file.FileName);

        var uploadResponse = await client.PutAsync(url, content, ct);
        return uploadResponse.IsSuccessStatusCode;
    }
}
