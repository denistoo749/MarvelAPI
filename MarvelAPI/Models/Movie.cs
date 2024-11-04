using System.ComponentModel.DataAnnotations;

namespace MarvelApI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public string Director { get; set; }
    }
}