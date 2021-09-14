using PocketMonster.Data.ContextDB;
using PocketMonster.Model.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public IPokemonRepository PokemonRepository { get; }
        public IGinasioRepository GinasioRepository { get; }
        public ITreinadorRepository TreinadorRepository { get; }

        public UnitOfWork(Context context)
        {
            _context = context;
            PokemonRepository = new PokemonRepository(context);
            GinasioRepository = new GinasioRepository(context);
            TreinadorRepository = new TreinadorRepository(context);
        }
    }
}
