using System.Collections.Generic;
using System.Linq;
using MarvelApI.Data;
using MarvelApI.Models;

namespace MarvelApI.Services
{
    public class MovieService : IMovieService
    {
        private readonly MarvelContext _context;

        public MovieService(MarvelContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.Find(id);
        }

        public void CreateMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            var existingMovie = _context.Movies.Find(movie.Id);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.ReleaseYear = movie.ReleaseYear;
                existingMovie.Director = movie.Director;
                _context.SaveChanges();
            }
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}