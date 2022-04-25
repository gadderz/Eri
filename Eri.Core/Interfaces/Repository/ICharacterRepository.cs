
namespace Eri.Core.Interfaces.Repository
{
    public interface ICharacterRepository
    {
        Task<Models.Character> GetByIdAsync(Guid id);
    }
}
