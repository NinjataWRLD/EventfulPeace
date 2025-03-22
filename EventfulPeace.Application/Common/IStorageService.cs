namespace EventfulPeace.Application.Common;

public interface IStorageService
{
    Task<string> GetPresignedGetUrlAsync(string key, string contentType);
    Task<(string Key, string Url)> GetPresignedPostUrlAsync(string folderPath, string name, string contentType, string fileName);
    Task DeleteFileAsync(string key, CancellationToken ct = default);
}
