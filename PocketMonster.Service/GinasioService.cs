using PocketMonster.Model.DTOs.InputModels;
using PocketMonster.Model.DTOs.OutputModels;
using PocketMonster.Model.Entities;
using PocketMonster.Model.Exceptions;
using PocketMonster.Model.Interfaces.Repository;
using PocketMonster.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Service
{
    public class GinasioService : IGinasioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GinasioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GinasioViewModel>> ListarGinasios()
        {
            var ginasios = await _unitOfWork.GinasioRepository.SelecionarTudo();

            List<GinasioViewModel> gyms = new();

            foreach (Ginasio ginasio in ginasios)
            {
                GinasioViewModel gym = new();
                gym.Cidade = ginasio.Cidade;
                gym.GymTipo = ginasio.GymTipo;
                gym.GymLider = ginasio.GymLider.Nome;
                gym.Id = ginasio.Id;
                gyms.Add(gym);
            }

            return gyms;
        }

        public async Task<GinasioViewModel> BuscarGinasioPorId(Guid id)
        {
            var gym = await _unitOfWork.GinasioRepository.SelecionarPorId(id);

            if (gym == null)
                throw new GinasioNaoEncontradoException();

            GinasioViewModel ginasio = new()
            {
                GymLider = gym.GymLider.Nome,
                Id = gym.Id,
                GymTipo = gym.GymTipo,
                Cidade = gym.Cidade
            };

            return ginasio;
        }

        public async Task<GinasioViewModel> BuscarGinasioPorNome(string nome)
        {
            var gym = await _unitOfWork.GinasioRepository.ProcurarPorNome(nome);

            if (gym == null)
                throw new GinasioNaoEncontradoException();

            GinasioViewModel ginasio = new()
            {
                GymLider = gym.GymLider.Nome,
                Id = gym.Id,
                GymTipo = gym.GymTipo,
                Cidade = gym.Cidade
            };

            return ginasio;
        }

        public async Task<GinasioViewModel> CriarGinasio(GinasioInputModel dto)
        {
            var gymValidar = await _unitOfWork.GinasioRepository.ProcurarPorNome(dto.Cidade.Trim().ToLower());
            if (gymValidar != null)
                throw new GinasioJaExisteException();

            var treinadorValidar = await _unitOfWork.TreinadorRepository.ProcurarPorNome(dto.GymLider.ToLower().Trim());
            if (treinadorValidar == null)
                throw new TreinadorNaoExisteException();

            var treinadorJaELider = await _unitOfWork.GinasioRepository.VerificarTreinadorLider(treinadorValidar);
            if (treinadorJaELider)
                throw new TreinadorJaELiderException();

            if (await _unitOfWork.TreinadorRepository.QuantidadeTipoPokemon(dto.GymTipo.Trim().ToLower(), dto.GymLider.ToLower().Trim()) < 6)
                throw new TreinadorNaoPodeSerLiderException();

            Ginasio gym = new()
            {
                GymLider = treinadorValidar,
                GymTipo = dto.GymTipo.Trim().ToLower(),
                Cidade = dto.Cidade.Trim().ToLower(),
                Id = Guid.NewGuid()
            };

            await _unitOfWork.GinasioRepository.Incluir(gym);

            GinasioViewModel ginasio = new()
            {
                GymLider = gym.GymLider.Nome,
                Id = gym.Id,
                GymTipo = gym.GymTipo,
                Cidade = gym.Cidade
            };

            return ginasio;
        }

        public async Task<GinasioViewModel> AlterarLider(Guid id, string nome)
        {
            Ginasio gym = await _unitOfWork.GinasioRepository.SelecionarPorId(id);
            Treinador trainer = await _unitOfWork.TreinadorRepository.ProcurarPorNome(nome);

            if (gym == null)
                throw new GinasioNaoEncontradoException();

            if (trainer == null)
                throw new TreinadorNaoExisteException();

            var treinadorJaELider = await _unitOfWork.GinasioRepository.VerificarTreinadorLider(trainer);
            if (treinadorJaELider)
                throw new TreinadorJaELiderException();

            if (await _unitOfWork.TreinadorRepository.QuantidadeTipoPokemon(gym.GymTipo, nome) < 6)
                throw new TreinadorNaoPodeSerLiderException();

            gym.GymLider = trainer;
            await _unitOfWork.GinasioRepository.Alterar(gym);

            GinasioViewModel ginasio = new()
            {
                GymLider = gym.GymLider.Nome,
                Id = gym.Id,
                GymTipo = gym.GymTipo,
                Cidade = gym.Cidade
            };

            return ginasio;
        }
    }
}
