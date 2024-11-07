using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarvelApI.Models;
using MarvelApI.Data;
using MarvelApI.DTOs;
using MarvelAPI.Repositories;

namespace MarvelApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly CharactersRepository _charactersRepository;

        public CharactersController(CharactersRepository charactersRepository)
        {
            _charactersRepository = charactersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> GetCharacters()
        {
            var CharacterDtos = await _charactersRepository.GetCharacters();
            return Ok(CharacterDtos);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
        {
            var characterDto = await _charactersRepository.GetCharacter(id);

            if (characterDto == null)
            {
                return NotFound();
            }

            return Ok(characterDto);
        }

        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            if (character == null)
            {
                return BadRequest("Character data is null.");
            }

            var addedCharacter = await _charactersRepository.PostCharacter(character);

            return CreatedAtAction(nameof(GetCharacter), new { id = addedCharacter.Id }, addedCharacter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, [FromBody] Character character)
        {
            if (id != character.Id)
            {
                return BadRequest("Character ID mismatch.");
            }

            var updateSuccessful = await _charactersRepository.PutCharacter(id, character);

            if (!updateSuccessful)
            {
                if (!await _charactersRepository.GetCharacter(id).ContinueWith(t => t.Result != null))
                {
                    return NotFound();
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var deletionSuccessful = await _charactersRepository.DeleteCharacter(id);

            if (!deletionSuccessful)
            {
                return NotFound($"Character with Id = {id} not found");
            }

            return NoContent();
        }
    }
}