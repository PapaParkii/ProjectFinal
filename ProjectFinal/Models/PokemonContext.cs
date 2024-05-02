using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ProjectFinal.Models
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions options)
            : base(options)
        { }
        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>().HasData(
                new Pokemon
                {
                    PokemonId = 1,
                    Name = "Charizard",
                    Generation = "Gen 1",
                    Region = "Kanto",
                    DateAdded = DateTime.Parse("2024-05-01")
                },
                new Pokemon
                {
                    PokemonId = 2,
                    Name = "Venusaur",
                    Generation = "Gen 1",
                    Region = "Kanto",
                    DateAdded = DateTime.Parse("2024-05-01")
                });
            }

    }
}
