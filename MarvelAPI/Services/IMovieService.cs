using System.Collections.Generic;
using MarvelApI.Models;

namespace MarvelApI.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        void CreateMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}