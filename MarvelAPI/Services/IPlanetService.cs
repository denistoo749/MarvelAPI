using System.Collections.Generic;
using MarvelApI.Models;

namespace MarvelApI.Services
{
    public interface IPlanetService
    {
        IEnumerable<Planet> GetAllPlanets();
        Planet GetPlanetById(int id);
        void CreatePlanet(Planet planet);
        void UpdatePlanet(Planet planet);
        void DeletePlanet(int id);
    }
}