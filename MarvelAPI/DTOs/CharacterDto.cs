using System.ComponentModel.DataAnnotations;

namespace MarvelApI.DTOs
{
    public class CharacterDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Alias { get; set; }

        public string Affiliation { get; set; }
        
        public int HomePlanetID { get; set; }
        
        public string HomePlanet { get; set; }
    }
}
