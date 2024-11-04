using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarvelApI.Models;
using MarvelApI.Data;
using MarvelApI.DTOs;

namespace MarvelApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly MarvelContext _context;

        public CharactersController(MarvelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> GetCharacters()
        {
            var characters = await _context.Characters.ToListAsync();

            // Map to DTOs
            var characterDtos = characters.Select(c => new CharacterDto
            {
                Id = c.Id,
                Name = c.Name,
                Alias = c.Alias,
                Affiliation = c.Affiliation,
                HomePlanetID = c.HomePlanetID, // Use HomePlanetID from Character model (ID)
                HomePlanet = c.HomePlanet       // Use HomePlanet from Character model (Name)
            });

            return Ok(characterDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            // Map to DTO
            var characterDto = new CharacterDto
            {
                Id = character.Id,
                Name = character.Name,
                Alias = character.Alias,
                Affiliation = character.Affiliation,
                HomePlanetID = character.HomePlanetID, // Use HomePlanetID from Character model (ID)
                HomePlanet = character.HomePlanet       // Use HomePlanet from Character model (Name)
            };

            return Ok(characterDto);
        }

        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}