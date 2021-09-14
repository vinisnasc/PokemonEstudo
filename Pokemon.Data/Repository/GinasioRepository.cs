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
    public class GinasioRepository : BaseRepository<Ginasio>, IGinasioRepository
    {
        private readonly Context _context;
        public GinasioRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override async Task<bool> Incluir(Ginasio gym)
        {
            return await base.Incluir(gym);
        }

        public async Task<Ginasio> ProcurarPorNome(string nome)
        {
            return await _context.Ginasios.FirstOrDefaultAsync(x => x.Cidade == nome);
        }
    }
}
