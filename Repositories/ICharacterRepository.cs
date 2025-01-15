using HeroCreator.Models;
using HeroCreator.ViewModels;

namespace HeroCreator.Repositories
{
    public interface ICharacterRepository
    {
        Task<Character?> GetByIdAsync(Guid id);
        Task<List<Character>> GetAllAsync();
        Task<Character> AddAsync(Character character);
        Task<Character> UpdateAsync(Character character);
        Task<bool> DeleteAsync(Guid id);
    }
}
