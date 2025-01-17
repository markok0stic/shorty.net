using Microsoft.AspNetCore.Mvc;
using Shorty.NET.Models;
using Shorty.NET.Services;

namespace Shorty.NET.Controllers;

public class HomeController : Controller
{
    private readonly UrlShorteningService _urlShorteningService;
    private readonly DbService _dbService;

    public HomeController(UrlShorteningService urlShorteningService, DbService dbService)
    {
        _urlShorteningService = urlShorteningService;
        _dbService = dbService;
    }

    public IActionResult Index()
    {
        return View(new UrlShorteningViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Index(UrlShorteningViewModel model)
    {
        if (string.IsNullOrWhiteSpace(model.OriginalUrl) || !Uri.TryCreate(model.OriginalUrl, UriKind.Absolute, out _))
        {
            model.Error = "Invalid URL. Please enter a valid URL.";
            return View(model);
        }

        try
        {
            var code = await _urlShorteningService.GenerateUniqueCode();
            var shortenedUrl = new ShortenedUrl
            {
                Id = Guid.NewGuid(),
                LongUrl = model.OriginalUrl,
                Code = code,
                ShortUrl = $"{Request.Scheme}://{Request.Host}/{code}",
                CreatedOnUtc = DateTime.UtcNow,
            };

            await _dbService.SaveUrl(code, shortenedUrl);
            model.ShortenedUrl = shortenedUrl.ShortUrl;
        }
        catch (Exception ex)
        {
            model.Error = $"An error occurred: {ex.Message}";
        }

        return View(model);
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> RedirectToOriginal(string code)
    {
        var shortenedUrl = await _dbService.ResolveUrl(code);
        if (shortenedUrl == null)
        {
            return NotFound("The requested URL could not be found.");
        }

        return Redirect(shortenedUrl.LongUrl);
    }
}