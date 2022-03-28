using Eri.Core.Interfaces.Repository;
using Eri.Core.Models;
using System;

namespace Eri.Database.Repository;

public class CharacterRepository : ICharacterRepository
{
    private readonly Context _context;

    public CharacterRepository(Context context)
    {
        _context = context;
    }

    public Task<Anime> GetByIdAsync(string id)
    {

    }
}
