namespace EventfulPeace.Web.Extensions;

public static class FileExtensions
{
    private const string InvalidSize = "File size must be greater than 0.";

    private static string GetRelativePath(string name)
        => $"{Path.Combine("images", name)}";

    private static string GetPath(this IWebHostEnvironment env, string fileName)
        => Path.Combine(env.WebRootPath, fileName);
    
    public static string GetFileExtension(this IFormFile file)
        => Path.GetExtension(file.FileName);

    public static async Task<string> UploadImageAsync(this IWebHostEnvironment env, IFormFile image, string name)
    {
        ArgumentNullException.ThrowIfNull(image, nameof(image));
        if (image.Length == 0)
        {
            throw new ArgumentException(InvalidSize, nameof(image));
        }

        string path = $"{name}{image.GetFileExtension()}";
        using FileStream stream = new(env.GetPath($"images\\{path}"), FileMode.Create);
        await image.CopyToAsync(stream).ConfigureAwait(false);

        return GetRelativePath(path);
    }

    public static void DeleteFile(this IWebHostEnvironment env, string name, string extension)
    {
        string path = env.GetPath(name + extension);
        File.Delete(path);
    }
}
