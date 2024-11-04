using MarvelApI.Models;
using System.Collections.Generic;

namespace MarvelApI.Services
{
    public interface ICharacterService
    {
        IEnumerable<Character> GetAllCharacters();
        Character GetCharacterById(int id);
        void CreateCharacter(Character character);
        void UpdateCharacter(Character character);
        void DeleteCharacter(int id);
    }
}