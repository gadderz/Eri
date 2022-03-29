using Eri.Core.Models;
using System;

namespace Eri.Core.Interfaces.Repository
{
    public interface IAnimeRepository
    {
        Task<bool> InsertAsync(Anime anime);
        Task<Anime> GetByIdAsync(string id);
        Task<bool> ReplaceAsync(Anime anime);
    }
}
