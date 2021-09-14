using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        public IPokemonRepository PokemonRepository { get; }
        public IGinasioRepository GinasioRepository { get; }
        public ITreinadorRepository TreinadorRepository { get; }

    }
}
