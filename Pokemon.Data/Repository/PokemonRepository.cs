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
    public class PokemonRepository : BaseRepository<Pokemon>, IPokemonRepository
    {
        private readonly Context _context;
        public PokemonRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override async Task<bool> Incluir(Pokemon pokemon)
        {
            return await base.Incluir(pokemon);
        }

        public async Task<Pokemon> SelecionarPorPokedex(int id)
        {
            return await contexto.Set<Pokemon>().FirstOrDefaultAsync(x => x.RegistroPokedex == id); ;
        }

        public override async Task<bool> Alterar(Pokemon pokemon)
        {
            return await base.Alterar(pokemon);
        }

        public async Task<Pokemon> ProcurarPorNome(string nome)
        {
            return await _context.Pokemon.FirstOrDefaultAsync(x => x.Nome == nome);
        }

    }
}
