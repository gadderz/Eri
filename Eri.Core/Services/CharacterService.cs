using Eri.Core.Models;
using System;

namespace Eri.Core.Services;

public class CharacterService
{
    public readonly AnimeService _animeService;

    public CharacterService(AnimeService animeService)
    {
        _animeService = animeService;
    }

    public async Task InsertAsync(Character character)
    {
        var anime = await _animeService.GetByIdAsync(character.Anime.Id);
        if (anime == null)
            throw new Exception($"Anime with id {character.Anime.Id} not found.");

        character.CreatedAt = DateTime.UtcNow;

        anime.Characters.Add(character);

        
    }
}
