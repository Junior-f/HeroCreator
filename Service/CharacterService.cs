using HeroCreator.Models;
using HeroCreator.ViewModels;
using HeroCreator.Repositories;

namespace HeroCreator.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly ILogger<CharacterService> _logger;

        public CharacterService(ICharacterRepository characterRepository, ILogger<CharacterService> logger)
        {
            _characterRepository = characterRepository;
            _logger = logger;
        }
        public async Task<CharacterViewModel> CreateAsync(CharacterViewModel character)
        {
            try
            {
                ValidateCharacter(character);
                var response = new Character
                {
                    Name = character.Name,
                    Class = character.Class,
                    Inventory = character.Inventory,
                    Attributes = character.Attributes,
                    Level = character.Level

                };
                var result = await _characterRepository.AddAsync(response);
                _logger.LogInformation("Character created successfully: {Id}", result.Id);
                return character;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating character: {Name}", character.Name);
                throw;
            }
        }
        public async Task<List<Character>> GetAllAsync()
        {
            try
            {
                return await _characterRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching characters.");
                throw;
            }
        }
        public async Task<Character?> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("Fetching character by ID: {Id}", id);

            try
            {
                return await _characterRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching character by ID: {Id}", id);
                throw;
            }
        }
        public async Task<Character> UpdateAsync(Character character)
        {
            try
            {
                var result = await _characterRepository.GetByIdAsync(character.Id);
                if (result == null)
                    throw new ArgumentException("Character not found.");

                result.Name = character.Name;
                result.Class = character.Class;
                result.Inventory = character.Inventory;
                result.Attributes = character.Attributes;
                result.Level = character.Level;

                return await _characterRepository.UpdateAsync(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating character: {Id}", character.Id);
                throw new InvalidOperationException("An error occurred while updating the character.", ex);
            }
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var character = await _characterRepository.GetByIdAsync(id);
                if (character == null)
                    throw new ArgumentException("Character not found.");

                return await _characterRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting character: {Id}", id);
                throw;
            }
        }
        private void ValidateCharacter(CharacterViewModel character)
        {
            if (string.IsNullOrWhiteSpace(character.Name))
                throw new InvalidOperationException("Character name is required.");

            if (string.IsNullOrWhiteSpace(character.Class))
                throw new InvalidOperationException("Character class is required.");

            if (string.IsNullOrWhiteSpace(character.Inventory))
                throw new InvalidOperationException("Character inventory is required.");

            if (string.IsNullOrWhiteSpace(character.Attributes))
                throw new InvalidOperationException("Character attributes are required.");

            if (character.Level < 1)
                throw new InvalidOperationException("Character level must be at least 1.");
        }
    }
}
