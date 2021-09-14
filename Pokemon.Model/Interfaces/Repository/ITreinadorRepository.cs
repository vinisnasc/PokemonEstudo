using PocketMonster.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.Interfaces.Repository
{
    public interface ITreinadorRepository
    {
        Task<bool> Incluir(Treinador treinador);
        Task<Treinador> ProcurarPorNome(string nome);
    }
}
