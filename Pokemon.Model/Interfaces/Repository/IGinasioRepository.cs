using PocketMonster.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.Interfaces.Repository
{
    public interface IGinasioRepository
    {
        Task<bool> Incluir(Ginasio gym);
        Task<Ginasio> ProcurarPorNome(string nome);
    }
}
