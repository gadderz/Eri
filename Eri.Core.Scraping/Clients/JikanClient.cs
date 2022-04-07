using System;

namespace Eri.Core.Scraping.Clients;

public class JikanClient
{
    private readonly HttpClient _client;

    public JikanClient(HttpClient client)
    {
        _client = client;
    }

    public async Task GetAnimesPagingAsync(int page, int limit)
    {

    }
}
