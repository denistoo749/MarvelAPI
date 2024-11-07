using MarvelApI.Data;
using MarvelApI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarvelAPI.Repositories
{
    public class PlanetsRepository
    {
        private readonly MarvelContext _context;

        public PlanetsRepository(MarvelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Planet>> GetPlanets()
        {
            return await _context.Planets.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Planet> GetPlanet(int id)
        {
            var planet = await _context.Planets.FindAsync(id);
            if (planet == null)
            {
                return null;
            }
            return planet;
        }

        [HttpPost]
        public async Task<Planet> PostPlanet(Planet planet)
        {
            _context.Planets.Add(planet);
            await _context.SaveChangesAsync();
            return planet;
        }

        [HttpPut("{id}")]
        public async Task<bool> PutPlanet(int id, Planet planet)
        {
            if (id != planet.Id)
            {
                return false;
            }

            _context.Entry(planet).State = EntityState.Modified;

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
        public async Task<bool> DeletePlanet(int id)
        {
            var planet = await _context.Planets.FindAsync(id);
            if (planet == null)
            {
                return false;
            }

            _context.Planets.Remove(planet);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool PlanetExists(int id)
        {
            return _context.Planets.Any(e => e.Id == id);
        }
    }
}
