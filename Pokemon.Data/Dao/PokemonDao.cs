using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocketMonster.Model;

namespace PocketMonster.Data.Dao
{
    public class PokemonDao : DaoBase
    {
        public async Task InserirPokemon(List<Pokemon> pokemon)
        {
            if (!pokemon.Any())
                return; // TODO: verificar com a Karina

            var check = "if (not exists(select 1 from Pokemon where IdPokemon = {0}))\n";
            var insert = "insert Pokemon (IdPokemon, Nome, Tipo1, Tipo2) values({0}, '{1}', '{2}', {3});\n";
            var comandos = pokemon.Select(p => string.Format(check, p.IdPokemon) + string.Format(insert, p.IdPokemon, p.Nome, p.Tipo1, p.Tipo2));

            await Insert(string.Join('\n', comandos));
        }
    }
}
