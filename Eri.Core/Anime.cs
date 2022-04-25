using Eri.Core.Interfaces.Repository;

namespace Eri.Core;

public class Anime
{
    private readonly IAnimeRepository _animeRepository;

    public Anime(IAnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    public async Task InsertAsync(Models.Anime anime)
    {
        anime.CreatedAt = DateTime.UtcNow;
        if (!await _animeRepository.InsertAsync(anime))
            throw new Exception();
    }

    public async Task<Models.Anime> GetByIdAsync(string id)
    {
        var result = await _animeRepository.GetByIdAsync(id);

        if (result is null)
            throw new Exception($"Anime with id {id} not found.");

        return result;
    }

}
