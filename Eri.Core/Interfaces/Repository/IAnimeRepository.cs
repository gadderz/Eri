using Eri.Core.Models;
using System;

namespace Eri.Core.Interfaces.Repository
{
    public interface IAnimeRepository
    {
        Task<bool> InsertAsync(Models.Anime anime);
        Task<Models.Anime> GetByIdAsync(string id);
        Task<bool> ReplaceAsync(Models.Anime anime);
    }
}
