using PocketMonster.Model.DTOs.InputModels;
using PocketMonster.Model.DTOs.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.Interfaces.Services
{
    public interface ITreinadorService
    {
        Task<List<TreinadorViewModel>> ListarTreinadores();
        Task<TreinadorViewModel> ProcurarPorId(Guid id);
        Task<TreinadorViewModel> ProcurarPorNome(string nome);
        Task<TreinadorViewModel> CadastrarTreinador(TreinadorInputModel dto);
        Task<TreinadorViewModel> CapturarPokemon(Guid id, string pokemon);
        Task<TreinadorViewModel> LibertaPokemon(Guid id, string pokeNome);
    }
}
