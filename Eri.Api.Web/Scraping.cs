using Eri.Core.Scraping;

namespace Eri.Api.Web;

public class Scraping
{
    private readonly Jikan _jikan;

    public Scraping(Jikan jikan)
    {
        _jikan = jikan;
    }

    public async Task AnimeAsync()
    {
        await _jikan.GetAnimesAsync();
    }
}
