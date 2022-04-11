using Eri.Core.Scraping.Clients;

namespace Eri.Core.Scraping;

public class Jikan
{
    private readonly JikanClient _client;

    public Jikan(JikanClient client)
    {
        _client = client;
    }

    public async Task GetAnimesAsync()
    {
        var result = await _client.GetAnimesPagingOrDefaultAsync(1,100);
    }
}
