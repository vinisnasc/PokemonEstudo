using PocketMonster.Model.DTOs.InputModels;
using PocketMonster.Model.DTOs.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.Interfaces.Services
{
    public interface IGinasioService
    {
        Task<List<GinasioViewModel>> ListarGinasios();
        Task<GinasioViewModel> BuscarGinasioPorId(Guid id);
        Task<GinasioViewModel> BuscarGinasioPorNome(string nome);
        Task<GinasioViewModel> CriarGinasio(GinasioInputModel dto);
        Task<GinasioViewModel> AlterarLider(Guid id, string nome);
    }
}
