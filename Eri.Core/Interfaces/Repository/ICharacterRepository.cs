using Eri.Core.Models;
using System;

namespace Eri.Core.Interfaces.Repository
{
    public interface ICharacterRepository
    {
        Task<Anime> GetByIdAsync(string id);
    }
}
