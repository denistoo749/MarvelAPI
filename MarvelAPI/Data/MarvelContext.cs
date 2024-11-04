using MarvelApI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarvelApI.Data
{
    public class MarvelContext : DbContext
    {
        public MarvelContext(DbContextOptions<MarvelContext> options)
            : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Series> Series { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Define the relationship between Character and Planet
            modelBuilder.Entity<Character>()
                .HasOne<Planet>()
                .WithMany(p => p.Characters)
                .HasForeignKey(c => c.HomePlanetID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}