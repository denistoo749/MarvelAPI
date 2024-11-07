using MarvelApI.Data;
using MarvelApI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarvelAPI.Repositories
{
    public class MoviesRepository
    {
        private readonly MarvelContext _context;

        public MoviesRepository(MarvelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Movie> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return null;
            }
            return movie;
        }

        [HttpPost]
        public async Task<Movie> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        [HttpPut("{id}")]
        public async Task<bool> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return false;
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return false;
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
