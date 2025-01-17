using HeroCreator.Models;
using HeroCreator.ViewModels;
using HeroCreator.Data;
using Microsoft.EntityFrameworkCore;

namespace HeroCreator.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly AppDbContext _context;
        public CharacterRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Character>> GetAllAsync()
        {
            return await _context.Characters.ToListAsync();
        }
        public async Task<Character?> GetByIdAsync(Guid id)
        {
            return await _context.Characters.FindAsync(id);
        }
        public async Task<Character> AddAsync(Character character)
        {
            _context.Characters?.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }
        public async Task<Character> UpdateAsync(Character character)
        {
            _context.Characters?.Update(character);
            await _context.SaveChangesAsync();
            return character;
        }
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
