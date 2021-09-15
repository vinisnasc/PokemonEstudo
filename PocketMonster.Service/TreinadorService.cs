using PocketMonster.Model.DTOs.InputModels;
using PocketMonster.Model.DTOs.OutputModels;
using PocketMonster.Model.Entities;
using PocketMonster.Model.Exceptions;
using PocketMonster.Model.Interfaces.Repository;
using PocketMonster.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMonster.Service
{
    public class TreinadorService : ITreinadorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TreinadorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TreinadorViewModel>> ListarTreinadores()
        {
            var treinadores = await _unitOfWork.TreinadorRepository.SelecionarTudo();
            List<TreinadorViewModel> lista = new();
            foreach(Treinador t in treinadores)
            {
                TreinadorViewModel trainer = new();
                trainer.Nome = t.Nome;
                trainer.IdTreinador = t.Id;
                trainer.Pokemons = new();
                foreach(PokemonTreinador p in t.PokemonCapturados)
                {
                    PokemonViewModel poke = new();
                    poke.Id = p.Pokemon.Id;
                    poke.Nome = p.Pokemon.Nome;
                    poke.RegistroPokedex = p.Pokemon.RegistroPokedex;
                    poke.Tipo1 = p.Pokemon.Tipo1;
                    poke.Tipo2 = p.Pokemon.Tipo2;
                    trainer.Pokemons.Add(poke);
                }
                lista.Add(trainer);
            }
            return lista;
        }

        public async Task<TreinadorViewModel> ProcurarPorId(Guid id)
        {
            var trainer = await _unitOfWork.TreinadorRepository.SelecionarPorId(id);

            if (trainer == null)
                return null;

            TreinadorViewModel treinador = new();
            treinador.Nome = trainer.Nome;
            treinador.IdTreinador = trainer.Id;

            if (trainer.PokemonCapturados == null)
            {
                treinador.Pokemons = null;
                return treinador;
            }

            treinador.Pokemons = new();
            foreach (PokemonTreinador p in trainer.PokemonCapturados)
            {
                PokemonViewModel poke = new();
                poke.Id = p.Pokemon.Id;
                poke.Nome = p.Pokemon.Nome;
                poke.RegistroPokedex = p.Pokemon.RegistroPokedex;
                poke.Tipo1 = p.Pokemon.Tipo1;
                poke.Tipo2 = p.Pokemon.Tipo2;
                treinador.Pokemons.Add(poke);
            }
            return treinador;
        }

        public async Task<TreinadorViewModel> ProcurarPorNome(string nome)
        {
            var trainer = await _unitOfWork.TreinadorRepository.ProcurarPorNome(nome.Trim().ToLower());

            if (trainer == null)
                return null;

            TreinadorViewModel treinador = new();
            treinador.Nome = trainer.Nome;
            treinador.IdTreinador = trainer.Id;

            if (trainer.PokemonCapturados == null)
            {
                treinador.Pokemons = new();
                return treinador;
            }

            treinador.Pokemons = new();
            foreach (PokemonTreinador p in trainer.PokemonCapturados)
            {
                PokemonViewModel poke = new();
                poke.Id = p.Pokemon.Id;
                poke.Nome = p.Pokemon.Nome;
                poke.RegistroPokedex = p.Pokemon.RegistroPokedex;
                poke.Tipo1 = p.Pokemon.Tipo1;
                poke.Tipo2 = p.Pokemon.Tipo2;
                treinador.Pokemons.Add(poke);
            }
            return treinador;
        }

        public async Task<TreinadorViewModel> CadastrarTreinador(TreinadorInputModel dto)
        {
            var trainer = await _unitOfWork.TreinadorRepository.ProcurarPorNome(dto.Nome.ToLower().Trim());

            if (trainer != null)
                throw new TreinadorJaExisteException();

            Treinador novo = new()
            {
                Nome = dto.Nome,
                Id = Guid.NewGuid(),
                PokemonCapturados = new()
            };

            TreinadorViewModel treinador = new()
            {
                IdTreinador = novo.Id,
                Nome = novo.Nome,
                Pokemons = null
            };

            return treinador;
        }
    }
}
