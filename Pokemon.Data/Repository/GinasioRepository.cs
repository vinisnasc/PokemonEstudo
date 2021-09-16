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
            return await _context.Ginasios.Include(x => x.GymLider).FirstOrDefaultAsync(x => x.Cidade == nome);
        }

        public async Task<bool> VerificarTreinadorLider(Treinador treinador)
        {
            return await _context.Ginasios.AnyAsync(x => x.GymLider == treinador);
        }

        public override async Task<bool> Alterar(Ginasio gym)
        {
            return await base.Alterar(gym);
        }

        public override async Task<List<Ginasio>> SelecionarTudo()
        {
            return await _context.Ginasios.Include(x => x.GymLider).ToListAsync();
        }

        public override async Task<Ginasio> SelecionarPorId(Guid id)
        {
            return await _context.Ginasios.Include(x => x.GymLider).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
