using HeroCreator.Models;
using HeroCreator.ViewModels;

namespace HeroCreator.Services
{
    public interface ICharacterService
    {
        Task<CharacterViewModel> CreateAsync(CharacterViewModel character);
        Task<List<Character>> GetAllAsync();
        Task<Character?> GetByIdAsync(Guid id);
        Task<Character> UpdateAsync(Character character);
        Task<bool> DeleteAsync(Guid id);
    }
}
