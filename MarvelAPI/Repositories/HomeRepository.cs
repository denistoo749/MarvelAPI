using MarvelApI.Data;
using Microsoft.AspNetCore.Mvc;

namespace MarvelAPI.Repositories
{
    public class HomeRepository
    {
        private readonly MarvelContext _context;

        public HomeRepository(MarvelContext context)
        {
            _context = context;
        }

        // GET: Characters/Details/{id}
        [HttpGet("characters/details/{id}")]
        public async Task<bool> CharacterDetails(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return false;
            }
            return true;
        }

        // GET: Planets/Details/{id}
        [HttpGet("planets/details/{id}")]
        public async Task<bool> PlanetDetails(int id)
        {
            var planet = await _context.Planets.FindAsync(id);
            if (planet == null)
            {
                return false;
            }
            return true;
        }

        // GET: Movies/Details/{id}
        [HttpGet("movies/details/{id}")]
        public async Task<bool> MovieDetails(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return false;
            }
            return true;
        }

        // GET: Series/Details/{id}
        [HttpGet("series/details/{id}")]
        public async Task<bool> SeriesDetails(int id)
        {
            var series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return false;
            }
            return true;
        }
    }
}
