using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.Exceptions
{
    public class PokemonNaoExisteException : Exception
    {
        public PokemonNaoExisteException() : base("Esse pokemon não existe")
        {}
    }

    public class TreinadorJaExisteException :Exception
    {
        public TreinadorJaExisteException() : base("Já existe um treinador com esse nome!")
        { }
    }
}
