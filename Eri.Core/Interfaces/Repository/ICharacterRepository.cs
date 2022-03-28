using Eri.Core.Models;

namespace Eri.Core.Interfaces.Repository
{
    public interface ICharacterRepository
    {
        Task<Character> GetByIdAsync(Guid id);
    }
}
