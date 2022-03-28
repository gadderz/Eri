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
        await _animeRepository.InsertAsync(anime);
    }

    public async Task<Anime> GetByIdAsync(string id)
    {
        return await _animeRepository.GetByIdAsync(id);
    }

}
