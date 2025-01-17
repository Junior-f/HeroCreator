using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using HeroCreator.Models;
using HeroCreator.ViewModels;
using HeroCreator.Services;

namespace HeroCreator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly ILogger<CharacterController> _logger;
        public CharacterController(ICharacterService characterService, ILogger<CharacterController> logger)
        {
            _characterService = characterService;
            _logger = logger;

        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all characters", Description = "Get all characters in the database.")]
        [SwaggerResponse(200, "Characters fetched successfully", typeof(List<Character>))]
        [SwaggerResponse(204, "Characters were not found")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var characters = await _characterService.GetAllAsync();

                if (characters == null)
                {
                    return NoContent();
                }
                return Ok(characters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get character by ID", Description = "Get a character by its ID.")]
        [SwaggerResponse(200, "Character fetched successfully", typeof(Character))]
        [SwaggerResponse(404, "Character not found")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var character = await _characterService.GetByIdAsync(id);
                if (character == null)
                {
                    return NotFound();
                }
                return Ok(character);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new character", Description = "Create a new character with the provided data.")]
        [SwaggerResponse(200, "Character created successfully", typeof(CharacterViewModel))]
        [SwaggerResponse(400, "Character data is invalid")]
        public async Task<IActionResult> Post([FromBody] CharacterViewModel newCharacter)
        {
            try
            {
                var createdCharacter = await _characterService.CreateAsync(newCharacter);
                return Ok(createdCharacter);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a character", Description = "Update a character with the provided data.")]
        [SwaggerResponse(200, "Character updated successfully", typeof(Character))]
        [SwaggerResponse(400, "Character is invalid")]
        [SwaggerResponse(404, "Character not found")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Character character)
        {
            try
            {
                character.Id = id;
                var result = await _characterService.UpdateAsync(character);
                if (result == null)
                    return NotFound();
                return Ok(character);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a character", Description = "Delete a character by its ID.")]
        [SwaggerResponse(200, "Character deleted successfully")]
        [SwaggerResponse(400, "Character id is required")]
        [SwaggerResponse(404, "Character not found")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest();

                var result = await _characterService.DeleteAsync(id);
                if (!result)
                    return NotFound();
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
