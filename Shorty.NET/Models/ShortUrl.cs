namespace Shorty.NET.Models;

public class ShortenUrlRequest
{
    public string Url { get; set; } = string.Empty;
}

public class ShortenedUrl
{
    public Guid Id { get; set; }
    public string LongUrl { get; set; } = string.Empty;
    public string ShortUrl { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public DateTime CreatedOnUtc { get; set; }
}