using PocketMonster.Model.DTOs.OutputModels;
using PocketMonster.Model.Interfaces.Repository;
using PocketMonster.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Service
{
    public class PokemonService : IPokemonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PokemonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PokemonViewModel>> ListarPokemon(int pagina, int quantidade)
        {
            var pokemon = await _unitOfWork.PokemonRepository.ListarPokemon(pagina, quantidade);

            return pokemon.Select(poke => new PokemonViewModel
            {
                Id = poke.Id,
                RegistroPokedex = poke.RegistroPokedex,
                Nome = poke.Nome,
                Tipo1 = poke.Tipo1,
                Tipo2 = poke.Tipo2
            }).ToList();
        }

        public async Task<PokemonViewModel> ProcurarPorRegistroPokedex(int registro)
        {
            var poke = await _unitOfWork.PokemonRepository.SelecionarPorPokedex(registro);

            if (poke == null)
                return null;

            PokemonViewModel pokemon = new()
            { 
                Id = poke.Id,
                RegistroPokedex = poke.RegistroPokedex,
                Nome = poke.Nome,
                Tipo1 = poke.Tipo1,
                Tipo2 = poke.Tipo2
            };
            return pokemon;
        }

        public async Task<PokemonViewModel> ProcurarPorNome(string nome)
        {
            var poke = await _unitOfWork.PokemonRepository.ProcurarPorNome(nome);

            if (poke == null)
                return null;

            PokemonViewModel pokemon = new()
            {
                Id = poke.Id,
                RegistroPokedex = poke.RegistroPokedex,
                Nome = poke.Nome,
                Tipo1 = poke.Tipo1,
                Tipo2 = poke.Tipo2
            };
            return pokemon;
        }

        public async Task<List<PokemonViewModel>> ListarPorTipo(string tipo)
        {
            var poke = await _unitOfWork.PokemonRepository.ListarPokemonPorTipo(tipo);

            return poke.Select(poke => new PokemonViewModel
            {
                Id = poke.Id,
                RegistroPokedex = poke.RegistroPokedex,
                Nome = poke.Nome,
                Tipo1 = poke.Tipo1,
                Tipo2 = poke.Tipo2
            }).ToList();
        }
    }
}
