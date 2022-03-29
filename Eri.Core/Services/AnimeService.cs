using Eri.Core.Interfaces.Repository;
using Eri.Core.Models;

namespace Eri.Core.Services;

public class AnimeService
{
    private readonly IAnimeRepository _animeRepository;

    public AnimeService(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task<Response> InsertAsync(Anime anime)
    {
        anime.CreatedAt = DateTime.UtcNow;
        if (await _animeRepository.InsertAsync(anime))
            return new Response();

        return new Response("");
    }

    public async Task<Response<Anime>> GetByIdAsync(string id)
    {
        var response = new Response<Anime>();

        var result = await _animeRepository.GetByIdAsync(id);
        response.Result = result;

        if (result is null)
            response.Errors.Add($"Anime with id {id} not found.");

        return response;
    }

    public async Task ReplaceAsync(Anime anime)
    {


    }

}
