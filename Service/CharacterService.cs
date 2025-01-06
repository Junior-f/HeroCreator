using HeroCreator.Models;
using HeroCreator.ViewModels;
using HeroCreator.Repositories;

namespace HeroCreator.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _repository;
        private readonly ILogger<CharacterService> _logger;

        public CharacterService(ICharacterRepository repository, ILogger<CharacterService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // Criar novo personagem (com regras de negócio)
        public async Task<CreateCharacterViewModel> CreateAsync(Character character)
        {

            try
            {
                ValidateCharacter(character);
                var result = await _repository.AddAsync(character);
                _logger.LogInformation("Character created successfully: {Id}", result);

                var response = new CreateCharacterViewModel
                {
                    Name = result.Name,
                    Class = result.Class,
                    Inventory = result.Inventory,
                    Attributes = result.Attributes,
                    Level = result.Level

                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating character: {Name}", character.Name);
                throw;
            }
        }

        // Buscar todos os personagens
        public async Task<List<Character>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching characters.");
                throw;
            }
        }

        // Buscar personagem pelo ID
        public async Task<Character?> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("Fetching character by ID: {Id}", id);

            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching character by ID: {Id}", id);
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Character character)
        {
            _logger.LogInformation("Updating character: {Id}", character.Id);

            try
            {
                var existingCharacter = await _repository.GetByIdAsync(character.Id);
                if (existingCharacter == null)
                    throw new ArgumentException("Character not found.");

                existingCharacter.Name = character.Name;
                existingCharacter.Class = character.Class;
                existingCharacter.Inventory = character.Inventory;
                existingCharacter.Attributes = character.Attributes;
                existingCharacter.Level = character.Level;

                return await _repository.UpdateAsync(existingCharacter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating character: {Id}", character.Id);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            _logger.LogInformation("Deleting character: {Id}", id);

            try
            {
                var character = await _repository.GetByIdAsync(id);
                if (character == null)
                    throw new ArgumentException("Character not found.");

                return await _repository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting character: {Id}", id);
                throw;
            }
        }
        private void ValidateCharacter(Character character)
        {
            if (string.IsNullOrWhiteSpace(character.Name))
                throw new ArgumentException("Character name is required.");

            if (character.Level < 1)
                throw new ArgumentException("Character level must be at least 1.");

            if (string.IsNullOrWhiteSpace(character.Class))
                throw new ArgumentException("Character class is required.");
        }
    }
}
