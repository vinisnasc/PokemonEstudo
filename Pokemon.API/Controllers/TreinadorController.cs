using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketMonster.Model.DTOs.InputModels;
using PocketMonster.Model.DTOs.OutputModels;
using PocketMonster.Model.Exceptions;
using PocketMonster.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMonster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreinadorController : ControllerBase
    {
        private readonly ITreinadorService _treinadorService;

        public TreinadorController(ITreinadorService treinadorService)
        {
            _treinadorService = treinadorService;
        }

        /// <summary>
        /// Lista todos os treinadores cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarTodosTreinadores")]
        public async Task<ActionResult<IEnumerable<TreinadorViewModel>>> ListarTreinadores()
        {
            var treinadores = await _treinadorService.ListarTreinadores();

            if (treinadores.Count() == 0)
                return NoContent();

            return Ok(treinadores);
        }

        /// <summary>
        /// Mostra os dados de um treinador a partir de seu ID
        /// </summary>
        /// <param name="id">Id do treinador</param>
        /// <returns></returns>
        [HttpGet("ProcurarPorId")]
        public async Task<ActionResult<TreinadorViewModel>> ProcurarPorId(Guid id)
        {
            var treinador = await _treinadorService.ProcurarPorId(id);

            if (treinador == null)
                return NoContent();

            return Ok(treinador);
        }

        /// <summary>
        /// Mostra os dados de um treinador a partir de seu nome
        /// </summary>
        /// <param name="nome">nome do treinador</param>
        /// <returns></returns>
        [HttpGet("ProcurarPorNome")]
        public async Task<ActionResult<TreinadorViewModel>> ProcurarPorNome(string nome)
        {
            var treinador = await _treinadorService.ProcurarPorNome(nome);

            if (treinador == null)
                return NoContent();

            return Ok(treinador);
        }

        /// <summary>
        /// Cadastra um novo treinador
        /// </summary>
        /// <param name="dto">Nome do treinador</param>
        /// <returns></returns>
        [HttpPost("CadastrarTreinador")]
        public async Task<ActionResult<TreinadorViewModel>> CadastrarTreinador([FromQuery] TreinadorInputModel dto)
        {
            try
            {
                var t = await _treinadorService.CadastrarTreinador(dto);
                return Ok(t);
            }
            catch (TreinadorJaExisteException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Adiciona um novo pokemon ao treinador
        /// </summary>
        /// <param name="id">id do treinador</param>
        /// <param name="pokeNome">Nome do pokemon</param>
        /// <returns></returns>
        [HttpPut("AdicionaUmPokemonAoTreinador")]
        public async Task<ActionResult<TreinadorViewModel>> AdicionarPoke([FromQuery] Guid id, string pokeNome)
        {
            try
            {
                var t = await _treinadorService.CapturarPokemon(id, pokeNome);
                return Ok(t);
            }
            catch (TreinadorNaoExisteException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Remove um pokemon do treinador
        /// </summary>
        /// <param name="id">id do treinador</param>
        /// <param name="pokeNome">Nome do pokemon</param>
        /// <returns></returns>
        [HttpPut("LiberaUmPokemon")]
        public async Task<ActionResult<TreinadorViewModel>> LibertaPoke([FromQuery] Guid id, string pokeNome)
        {
            try
            {
                var t = await _treinadorService.LibertaPokemon(id, pokeNome);
                return Ok(t);
            }
            catch (TreinadorNaoExisteException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
