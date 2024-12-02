using Microsoft.AspNetCore.Mvc;
using HeroCreator.Models;
using HeroCreator.Repositories;
using HeroCreator.Services;

namespace HeroCreator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterService _service;

        public CharacterController(CharacterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var characters = await _service.GetAllAsync();
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var character = await _service.GetByIdAsync(id);
            if (character == null) return NotFound("Character not found.");
            return Ok(character);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Character newCharacter)
        {
            var createdCharacter = await _service.CreateAsync(newCharacter);
            return CreatedAtAction(nameof(GetById), new { id = createdCharacter.Id }, createdCharacter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Character updatedCharacter)
        {
            updatedCharacter.Id = id;
            var success = await _service.UpdateAsync(updatedCharacter);
            if (!success) return NotFound("Character not found.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound("Character not found.");
            return NoContent();
        }
    }
}
