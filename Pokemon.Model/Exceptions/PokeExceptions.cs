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

    public class TreinadorNaoExisteException : Exception
    {
        public TreinadorNaoExisteException() : base("Não existe um treinador com esse nome!")
        { }
    }

    public class TreinadorJaTemEspecieException : Exception
    {
        public TreinadorJaTemEspecieException() : base("O treinador já tem um pokemon dessa espécie!")
        { }
    }

    public class TreinadorNaoTemEspecieException : Exception
    {
        public TreinadorNaoTemEspecieException() : base("O treinador não tem um pokemon dessa espécie!")
        { }
    }

    public class GinasioNaoEncontradoException : Exception
    {
        public GinasioNaoEncontradoException() : base("Não existe ginasio com a informacao informada!")
        { }
    }

    public class GinasioJaExisteException : Exception
    {
        public GinasioJaExisteException() : base("Já existe um ginasio na cidade informada!")
        { }
    }

    public class TreinadorJaELiderException : Exception
    {
        public TreinadorJaELiderException() : base("Esse treinador já é lider de algum ginasio!")
        { }
    }

    public class TreinadorNaoPodeSerLiderException : Exception
    {
        public TreinadorNaoPodeSerLiderException() : base("Esse treinador tem menos de 6 pokemons do tipo do ginasio!")
        { }
    }
}
