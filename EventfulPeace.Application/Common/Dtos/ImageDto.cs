namespace EventfulPeace.Application.Common.Dtos;

public class ImageDto
{
    public string Path { get; set; } = string.Empty;
    public string Extension => '.' + Path.Split('.')[^1].ToLower();
}
