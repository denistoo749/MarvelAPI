using System.Collections.Generic;
using System.Linq;
using MarvelApI.Data;
using MarvelApI.Models;

namespace MarvelApI.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly MarvelContext _context;

        public PlanetService(MarvelContext context)
        {
            _context = context;
        }

        public IEnumerable<Planet> GetAllPlanets()
        {
            return _context.Planets.ToList();
        }

        public Planet GetPlanetById(int id)
        {
            return _context.Planets.Find(id);
        }

        public void CreatePlanet(Planet planet)
        {
            _context.Planets.Add(planet);
            _context.SaveChanges();
        }

        public void UpdatePlanet(Planet planet)
        {
            var existingPlanet = _context.Planets.Find(planet.Id);
            if (existingPlanet != null)
            {
                existingPlanet.Name = planet.Name;
                existingPlanet.Climate = planet.Climate;
                existingPlanet.Terrain = planet.Terrain;
                existingPlanet.Population = planet.Population;
                _context.SaveChanges();
            }
        }

        public void DeletePlanet(int id)
        {
            var planet = _context.Planets.Find(id);
            if (planet != null)
            {
                _context.Planets.Remove(planet);
                _context.SaveChanges();
            }
        }
    }
}