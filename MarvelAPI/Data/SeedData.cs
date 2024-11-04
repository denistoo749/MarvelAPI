using MarvelApI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MarvelApI.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<MarvelContext>();

                // Check if the database is already seeded
                if (context.Characters.Any() || context.Movies.Any() || context.Planets.Any() || context.Series.Any())
                {
                    return; // DB has been seeded
                }

                // Create planets
                var earth = new Planet { Name = "Earth", Climate = "Temperate", Terrain = "Varied", Population = 7800000000 };
                var asgard = new Planet { Name = "Asgard", Climate = "Temperate", Terrain = "Mountainous", Population = 5000000 };

                // Save planets first
                context.Planets.AddRange(earth, asgard);
                context.SaveChanges(); // Save planets to get their IDs

                context.Characters.AddRange(
                    new Character { Name = "Tony Stark", Alias = "Iron Man", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Thor Odinson", Alias = "Thor", Affiliation = "Avengers", HomePlanetID = asgard.Id, HomePlanet = asgard.Name },
                    new Character { Name = "Steve Rogers", Alias = "Captain America", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Bruce Banner", Alias = "Hulk", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name }
                );

                context.Movies.AddRange(
                    new Movie { Title = "The Avengers", ReleaseYear = 2012, Director = "Joss Whedon" },
                    new Movie { Title = "Avengers: Endgame", ReleaseYear = 2019, Director = "Anthony and Joe Russo" },
                    new Movie { Title = "Thor: Ragnarok", ReleaseYear = 2017, Director = "Taika Waititi" }
                );

                context.Series.AddRange(
                    new Series { Title = "Agents of S.H.I.E.L.D.", Description = "A group of agents from S.H.I.E.L.D. investigate strange occurrences.", Seasons = 7, ReleaseYear = 2013 },
                    new Series { Title = "WandaVision", Description = "Wanda Maximoff and Vision are living idealized suburban lives.", Seasons = 1, ReleaseYear = 2021 },
                    new Series { Title = "Loki", Description = "The God of Mischief is back in this time-bending series.", Seasons = 1, ReleaseYear = 2021 }
                );

                context.SaveChanges(); // Save all changes
            }
        }
    }
}
