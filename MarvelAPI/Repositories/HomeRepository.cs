//using MarvelApI.Data;
//using Microsoft.AspNetCore.Mvc;

//namespace MarvelAPI.Repositories
//{
//    public class HomeRepository
//    {
//        private readonly MarvelContext _context;

//        public HomeRepository(MarvelContext context)
//        {
//            _context = context;
//        }

//        // GET: Home
//        public IActionResult Index()
//        {
//            return View();
//        }

//        // GET: Characters/Details/{id}
//        [HttpGet("characters/details/{id}")]
//        public async Task<IActionResult> CharacterDetails(int id)
//        {
//            var character = await _context.Characters.FindAsync(id);
//            if (character == null)
//            {
//                return null; // Return a 404 if the character is not found
//            }
//            return View("CharacterDetails", character); // Return a view with character details
//        }

//        // GET: Planets/Details/{id}
//        [HttpGet("planets/details/{id}")]
//        public async Task<IActionResult> PlanetDetails(int id)
//        {
//            var planet = await _context.Planets.FindAsync(id);
//            if (planet == null)
//            {
//                return NotFound(); // Return a 404 if the planet is not found
//            }
//            return View("PlanetDetails", planet); // Return a view with planet details
//        }

//        // GET: Movies/Details/{id}
//        [HttpGet("movies/details/{id}")]
//        public async Task<IActionResult> MovieDetails(int id)
//        {
//            var movie = await _context.Movies.FindAsync(id);
//            if (movie == null)
//            {
//                return NotFound(); // Return a 404 if the movie is not found
//            }
//            return View("MovieDetails", movie); // Return a view with movie details
//        }

//        // GET: Series/Details/{id}
//        [HttpGet("series/details/{id}")]
//        public async Task<IActionResult> SeriesDetails(int id)
//        {
//            var series = await _context.Series.FindAsync(id);
//            if (series == null)
//            {
//                return NotFound(); // Return a 404 if the series is not found
//            }
//            return View("SeriesDetails", series); // Return a view with series details
//        }

//        // Optional: Error action for error handling
//        public IActionResult Error()
//        {
//            return View();
//        }
//    }
//}
