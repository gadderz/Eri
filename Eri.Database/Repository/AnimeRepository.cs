using Eri.Core.Interfaces.Repository;
using Eri.Core.Models;

namespace Eri.Database.Repository;

public class AnimeRepository : IAnimeRepository
{
    private readonly Context _context;

    public AnimeRepository(Context context)
    {
        _context = context;
    }

    public async Task<Anime> GetByIdAsync(string id)
    {
        return await _context.Anime.FindByIdAsync(id);
    }

    public async Task<bool> InsertAsync(Anime anime)
    {
        return (await _context.Anime.InsertAsync(anime)) == 1;
    }

    public async Task<bool> ReplaceAsync(Anime anime)
    {
        return (await _context.Anime.ReplaceAsync(anime)) == 1;
    }
}
