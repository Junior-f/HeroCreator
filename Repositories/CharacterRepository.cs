using HeroCreator.Data;
using HeroCreator.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroCreator.Repositories
{
    public class CharacterRepository
    {
        private readonly AppDbContext _context;

        public CharacterRepository(AppDbContext context)
        {
            _context = context;
        }

        // Create
        public async Task<Character> AddAsync(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        // Read All
        public async Task<List<Character>> GetAllAsync()
        {
            return await _context.Characters.ToListAsync();
        }

        // Read By ID
        public async Task<Character?> GetByIdAsync(Guid id)
        {
            return await _context.Characters.FindAsync(id);
        }

        // Update
        public async Task<bool> UpdateAsync(Character character)
        {
            var existingCharacter = await _context.Characters.FindAsync(character.Id);
            if (existingCharacter == null) return false;

            existingCharacter.Name = character.Name;
            existingCharacter.Class = character.Class;
            existingCharacter.Inventory = character.Inventory;
            existingCharacter.Attributes = character.Attributes;
            existingCharacter.Level = character.Level;

            await _context.SaveChangesAsync();
            return true;
        }

        // Delete
        public async Task<bool> DeleteAsync(Guid id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null) return false;

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
