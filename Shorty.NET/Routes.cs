using Shorty.NET.Models;
using Shorty.NET.Services;

namespace Shorty.NET;

public static class Routes
{
    public static WebApplication RegisterApplicationRoutes(this WebApplication app)
    {
        app.MapPost("api/shorten", async (ShortenUrlRequest request,
            UrlShorteningService shorteningService,
            DbService dbService,
            HttpContext context) =>
        {
            if (!Uri.TryCreate(request.Url, UriKind.Absolute, out _))
                return Results.BadRequest("Invalid specified url.");
            
            var code = await shorteningService.GenerateUniqueCode();
            var shortenedUrl = new ShortenedUrl
            {
                Id = Guid.NewGuid(),
                LongUrl = request.Url,
                Code = code,
                ShortUrl = $"{context.Request.Scheme}://{context.Request.Host}/api/{code}",
                CreatedOnUtc = DateTime.UtcNow,
            };
            await dbService.SaveUrl(code, shortenedUrl);
            return Results.Ok(shortenedUrl.ShortUrl);
        });

        app.MapGet("api/{code}", async (string code, DbService dbService) =>
        {
            var shortenedUrl = await dbService.ResolveUrl(code);
            if (shortenedUrl == null)
                return Results.NotFound();
            
            return Results.Redirect(shortenedUrl.LongUrl);
        });

        return app;
    }
}