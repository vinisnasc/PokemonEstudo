using Microsoft.EntityFrameworkCore;
using PocketMonster.Data.ContextDB;
using PocketMonster.Model.DTOs.OutputModels;
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
            return await _context.Treinadores.Include(x => x.PokemonCapturados).ThenInclude(x => x.Pokemon).FirstOrDefaultAsync(x => x.Nome == nome);
        }

        public async Task<int> QuantidadeTipoPokemon(string tipo, string nome)
        {
            Treinador Treinador = await ProcurarPorNome(nome);
            int count = 0;

            foreach (PokemonTreinador pkmn in Treinador.PokemonCapturados)
            {
                if (pkmn.Pokemon.Tipo1 == tipo)
                    count++;

                if (pkmn.Pokemon.Tipo2 == tipo)
                    count++;
            }

            return count;
        }

        public override async Task<bool> Alterar(Treinador treinador)
        {
            return await base.Alterar(treinador);
        }

        public override async Task<List<Treinador>> SelecionarTudo()
        {
            return await _context.Treinadores.Include(x => x.PokemonCapturados).ThenInclude(x => x.Pokemon).ToListAsync();
        }

        public override async Task<Treinador> SelecionarPorId(Guid id)
        {
            return await _context.Treinadores.Include(x => x.PokemonCapturados).ThenInclude(x => x.Pokemon).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

