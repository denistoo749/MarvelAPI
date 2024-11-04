using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarvelApI.Models
{
    public class Character
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Alias { get; set; }

        public string Affiliation { get; set; }

        // Foreign key
        public int HomePlanetID { get; set; }

        public string HomePlanet { get; set; }
    }
}
