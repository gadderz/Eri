using Eri.Core.Scraping.Models;
using System.Text.Json;

namespace Eri.Core.Scraping.Clients;

public class JikanClient
{
    private readonly HttpClient _client;

    public JikanClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<Response<List<Models.Anime>>> GetAnimesPagingOrDefaultAsync(int page, int limit)
    {

        var response = await _client.GetAsync(_client.BaseAddress + $"anime?page={page}&limit={limit}");
        if (response.IsSuccessStatusCode)
        {
            var resultString  = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Response<List<Models.Anime>>>(resultString);

            if (result is null)
                throw new Exception("Error to convert json.");

            return result;
        }

        return default;
    }
}
