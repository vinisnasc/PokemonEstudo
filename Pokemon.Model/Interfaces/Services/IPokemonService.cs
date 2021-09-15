using PocketMonster.Model.DTOs.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.Interfaces.Services
{
    public interface IPokemonService
    {
        Task<List<PokemonViewModel>> ListarPokemon(int pagina, int quantidade);
        Task<PokemonViewModel> ProcurarPorRegistroPokedex(int registro);
        Task<PokemonViewModel> ProcurarPorNome(string nome);
        Task<List<PokemonViewModel>> ListarPorTipo(string tipo);
    }
}
