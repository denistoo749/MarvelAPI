using System.ComponentModel.DataAnnotations;

namespace MarvelApI.DTOs
{
    public class PlanetDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Climate { get; set; }

        public string Terrain { get; set; }

        public long Population { get; set; }
    }
}