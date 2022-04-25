using Eri.Core.Interfaces.Repository;

namespace Eri.Core;

public class Character
{
    public readonly ICharacterRepository _characterRepository;
    public readonly Anime _animeService;

    public Character(Anime animeService, ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
        _animeService = animeService;
    }

    public async Task InsertAsync(Models.Character character)
    {
        var anime = await _animeService.GetByIdAsync(character.Anime.Id);
        if (anime is null)
            throw new Exception($"Anime with id {character.Anime.Id} not found.");

        character.CreatedAt = DateTime.UtcNow;

        anime.Characters.Add(character);
        
    }
}
