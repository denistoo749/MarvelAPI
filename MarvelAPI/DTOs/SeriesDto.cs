﻿using System.ComponentModel.DataAnnotations;

namespace MarvelApI.DTOs
{
    public class SeriesDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int Seasons { get; set; }

        public int ReleaseYear { get; set; }
    }
}