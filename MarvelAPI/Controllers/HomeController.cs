using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MarvelApI.Data;
using MarvelAPI.Repositories;

namespace MarvelAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeRepository _homeRepository;

        public HomeController(HomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        // GET: Home
        public IActionResult Index()
        {
            return View();
        }

        // GET: About
        public IActionResult About()
        {
            return View();
        }

        // GET: Characters/Details/{id}
        [HttpGet("characters/details/{id}")]
        public async Task<IActionResult> CharacterDetails(int id)
        {
            var character = await _homeRepository.CharacterDetails(id);
            if (character == null)
            {
                return NotFound();
            }
            return View("CharacterDetails", character);
        }

        // GET: Planets/Details/{id}
        [HttpGet("planets/details/{id}")]
        public async Task<IActionResult> PlanetDetails(int id)
        {
            var planet = await _homeRepository.PlanetDetails(id);
            if (planet == null)
            {
                return NotFound();
            }
            return View("PlanetDetails", planet);
        }

        // GET: Movies/Details/{id}
        [HttpGet("movies/details/{id}")]
        public async Task<IActionResult> MovieDetails(int id)
        {
            var movie = await _homeRepository.MovieDetails(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View("MovieDetails", movie);
        }

        // GET: Series/Details/{id}
        [HttpGet("series/details/{id}")]
        public async Task<IActionResult> SeriesDetails(int id)
        {
            var series = await _homeRepository.SeriesDetails(id);
            if (series == null)
            {
                return NotFound();
            }
            return View("SeriesDetails", series);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}