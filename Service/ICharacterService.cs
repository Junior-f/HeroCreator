using HeroCreator.Models;
using HeroCreator.ViewModels;

namespace HeroCreator.Services
{
    public interface ICharacterService
    {
        Task<CreateCharacterViewModel> CreateAsync(CreateCharacterViewModel character);
        Task<List<Character>> GetAllAsync();
        Task<Character?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(Character character);
        Task<bool> DeleteAsync(Guid id);
    }
}
