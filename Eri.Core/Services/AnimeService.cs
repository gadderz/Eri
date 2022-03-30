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

    public async Task InsertAsync(Anime anime)
    {
        anime.CreatedAt = DateTime.UtcNow;
        if (!await _animeRepository.InsertAsync(anime))
            throw new Exception();
    }

    public async Task<Anime> GetByIdAsync(string id)
    {
        var result = await _animeRepository.GetByIdAsync(id);

        if (result is null)
            throw new Exception($"Anime with id {id} not found.");

        return result;
    }

}
