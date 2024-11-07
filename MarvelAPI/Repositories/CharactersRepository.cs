using MarvelApI.Data;
using MarvelApI.DTOs;
using MarvelApI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarvelAPI.Repositories
{
    public class CharactersRepository
    {
        private readonly MarvelContext _context;

        public CharactersRepository(MarvelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CharacterDto>> GetCharacters()
        {
            var characters = await _context.Characters.ToListAsync();

            var characterDtos = characters.Select(c => new CharacterDto
            {
                Id = c.Id,
                Name = c.Name,
                Alias = c.Alias,
                Affiliation = c.Affiliation,
                HomePlanetID = c.HomePlanetID, // Use HomePlanetID from Character model (ID)
                HomePlanet = c.HomePlanet       // Use HomePlanet from Character model (Name)
            });

            return characterDtos;
        }

        public async Task<CharacterDto> GetCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return null;
            }

            // Map to DTO
            var characterDto = new CharacterDto
            {
                Id = character.Id,
                Name = character.Name,
                Alias = character.Alias,
                Affiliation = character.Affiliation,
                HomePlanetID = character.HomePlanetID,
                HomePlanet = character.HomePlanet
            };

            return characterDto;
        }

        public async Task<Character> PostCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<bool> PutCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return false;
            }

            _context.Entry(character).State = EntityState.Modified; // Mark entity as modified

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return false;
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }

    }
}
