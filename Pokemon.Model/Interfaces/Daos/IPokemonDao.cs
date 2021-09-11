using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.Interfaces.Daos
{
    public interface IPokemonDao
    {
        Task InserirPokemon(List<Pokemon> pokemon);
    }
}
