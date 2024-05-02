using ProjectFinal.Models;
using ProjectFinal.Repositories;

namespace ProjectFinal.Services
{
    public interface IUnitOfWork
    {
        IPokemonRepository PokemonRepository { get; }
        void Save();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly PokemonContext _context;

        public UnitOfWork(PokemonContext context)
        {
            _context = context;
            PokemonRepository = new PokemonRepository(_context);
        }

        public IPokemonRepository PokemonRepository { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}