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
        public async Task<CreateCharacterViewModel> CreateAsync(CreateCharacterViewModel character)
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
                _logger.LogInformation("Character created successfully: {Id}", result);
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
        public async Task<bool> UpdateAsync(Character character)
        {
            _logger.LogInformation("Updating character: {Id}", character.Id);

            try
            {
                var existingCharacter = await _characterRepository.GetByIdAsync(character.Id);
                if (existingCharacter == null)
                    throw new ArgumentException("Character not found.");

                existingCharacter.Name = character.Name;
                existingCharacter.Class = character.Class;
                existingCharacter.Inventory = character.Inventory;
                existingCharacter.Attributes = character.Attributes;
                existingCharacter.Level = character.Level;

                return await _characterRepository.UpdateAsync(existingCharacter);
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
        private void ValidateCharacter(CreateCharacterViewModel character)
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
