using Eri.Core.Scraping;
using System;

namespace Eri.Api.Web.Services;

public class ScrapingWebService
{
    private readonly Jikan _jikan;

    public ScrapingWebService(Jikan jikan)
    {
        _jikan = jikan;
    }

    public async Task AnimeAsync()
    {
        await _jikan.GetAnimesAsync();
    }
}
