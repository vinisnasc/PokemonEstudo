using PocketMonster.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.Interfaces.Repository
{
    public interface IPokemonRepository
    {
        Task<bool> Incluir(Pokemon pokemon);
        Task<Pokemon> SelecionarPorPokedex(int id);
        Task<bool> Alterar(Pokemon pokemon);
        Task<Pokemon> ProcurarPorNome(string nome);
        Task<List<Pokemon>> ListarPokemon(int pagina, int quantidade);
        Task<List<Pokemon>> ListarPokemonPorTipo(string tipo);
    }
}
