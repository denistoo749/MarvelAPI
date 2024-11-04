using System.Collections.Generic;
using System.Linq;
using MarvelApI.Data;
using MarvelApI.Models;

namespace MarvelApI.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly MarvelContext _context;

        public CharacterService(MarvelContext context)
        {
            _context = context;
        }

        public IEnumerable<Character> GetAllCharacters()
        {
            return _context.Characters.ToList();
        }

        public Character GetCharacterById(int id)
        {
            return _context.Characters.Find(id);
        }

        public void CreateCharacter(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
        }

        public void UpdateCharacter(Character character)
        {
            var existingCharacter = _context.Characters.Find(character.Id);
            if (existingCharacter != null)
            {
                existingCharacter.Name = character.Name;
                existingCharacter.Alias = character.Alias;
                existingCharacter.Affiliation = character.Affiliation;
                existingCharacter.HomePlanetID = character.HomePlanetID;
                existingCharacter.HomePlanet= character.HomePlanet;
                _context.SaveChanges();
            }
        }

        public void DeleteCharacter(int id)
        {
            var character = _context.Characters.Find(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
                _context.SaveChanges();
            }
        }
    }
}