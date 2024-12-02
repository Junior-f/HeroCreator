using HeroCreator.Models;
using HeroCreator.Data;
using HeroCreator.Repositories;

namespace HeroCreator.Services
{
    public class CharacterService
    {
        // Create
        private readonly CharacterRepository _repository;

        public CharacterService(CharacterRepository repository)
        {
            _repository = repository;
        }

        public Task<Character> CreateAsync(Character character)
        {
            return _repository.AddAsync(character);
        }

        public Task<List<Character>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Character?> GetByIdAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(Character character)
        {
            return _repository.UpdateAsync(character);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}

