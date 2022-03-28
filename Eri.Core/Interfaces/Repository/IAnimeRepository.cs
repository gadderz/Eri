using Eri.Core.Models;
using System;

namespace Eri.Core.Interfaces.Repository
{
    public interface IAnimeRepository
    {
        Task InsertAsync(Anime anime);
        Task<Anime> GetByIdAsync(string id);
        Task ReplaceAsync(Anime anime);
    }
}
