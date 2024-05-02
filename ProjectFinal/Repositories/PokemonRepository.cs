using ProjectFinal.Models;
using System.Linq;

namespace ProjectFinal.Repositories
{
    public interface IPokemonRepository
    {
        IQueryable<Pokemon> GetAll();
        IQueryable<Pokemon> GetByRegion(string region);
        Pokemon GetById(int id);
        void Add(Pokemon pokemon);
        void Update(Pokemon pokemon);
        void Delete(Pokemon pokemon);
    }

    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokemonContext _context;

        public PokemonRepository(PokemonContext context)
        {
            _context = context;
        }

        public IQueryable<Pokemon> GetAll()
        {
            return _context.Pokemons;
        }

        public IQueryable<Pokemon> GetByRegion(string region)
        {
            return _context.Pokemons.Where(p => p.Region == region);
        }

        public Pokemon GetById(int id)
        {
            return _context.Pokemons.Find(id);
        }

        public void Add(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
        }

        public void Update(Pokemon pokemon)
        {
            _context.Pokemons.Update(pokemon);
        }

        public void Delete(Pokemon pokemon)
        {
            _context.Pokemons.Remove(pokemon);
        }
    }
}