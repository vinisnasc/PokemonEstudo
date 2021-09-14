using Microsoft.EntityFrameworkCore;
using PocketMonster.Data.ContextDB;
using PocketMonster.Model.Entities;
using PocketMonster.Model.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Data.Repository
{
    public class TreinadorRepository : BaseRepository<Treinador>, ITreinadorRepository
    {
        private readonly Context _context;
        public TreinadorRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override async Task<bool> Incluir(Treinador treinador)
        {
            return await base.Incluir(treinador);
        }

        public async Task<Treinador> ProcurarPorNome(string nome)
        {
            return await _context.Treinadores.FirstOrDefaultAsync(x => x.Nome == nome);
        }
    }
}
