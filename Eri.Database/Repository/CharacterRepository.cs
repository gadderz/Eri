using Eri.Core.Interfaces.Repository;
using Eri.Core.Models;

namespace Eri.Database.Repository;

public class CharacterRepository : ICharacterRepository
{
    private readonly Context _context;

    public CharacterRepository(Context context)
    {
        _context = context;
    }

    private async Task PopulateAsync(Character character, Anime anime)
    {
        anime.Characters.Clear();
        character.Anime = anime;

        await Task.CompletedTask;
    }

    public async Task<Character> GetByIdAsync(Guid id)
    {
        var anime = await _context.Anime.FirstOrDefaultAsync(f=>f.Characters.Any(c => c.Id == id));
        if(anime == default)
            return null;

        var character = anime.Characters.First(f=>f.Equals(id));

        await PopulateAsync(character, anime);

        return character;

    }
}
