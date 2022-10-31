using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PocketMonster.Model.DTOs.OutputModels;
using PocketMonster.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMonster.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        /// <summary>
        /// Retorna todos os pokemon, com a quantidade informada e a pagina informada
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarTodosPokemon")]
        public async Task<ActionResult<IEnumerable<PokemonViewModel>>> ListarTodos([FromQuery, Range(1, int.MaxValue)] int pag =1, [FromQuery, Range(1,50)] int qtd = 5)
        {
            var pokemon = await _pokemonService.ListarPokemon(pag, qtd);

            if (pokemon.Count() == 0)
                return NoContent();

            return Ok(pokemon);
        }

        /// <summary>
        /// Lista todos os pokemon conforme o tipo que você digitar
        /// </summary>
        /// <param name="tipo">Digite o tipo escolhido</param>
        /// <returns></returns>
        [HttpGet("ListarTodosPokemonPorTipo")]
        public async Task<ActionResult<IEnumerable<PokemonViewModel>>> ListarPorTipo(string tipo)
        {
            var pokemon = await _pokemonService.ListarPorTipo(tipo.Trim().ToLower());

            if (pokemon.Count() == 0)
                return NoContent();

            return Ok(pokemon);
        }

        /// <summary>
        /// Retorna os dados do pokemon de acordo com seu número na Pokedex
        /// </summary>
        /// <param name="numPoke">Coloque o número de registro na pokedex</param>
        [HttpGet("ProcurarPorPokedex")]
        public async Task<ActionResult<PokemonViewModel>> ProcurarPorPokedex(int numPoke)
        {
                var poke = await _pokemonService.ProcurarPorRegistroPokedex(numPoke);
                if (poke != null)
                    return Ok(poke);

                else
                    return BadRequest("Pokemon não existe");
        }

        /// <summary>
        /// Retorna o pokemon cujo nome foi informado
        /// </summary>
        /// <param name="pokeNome">Informe o nome do pokemon</param>
        /// <returns></returns>
        [HttpGet("ProcurarPorNome")]
        public async Task<ActionResult<PokemonViewModel>> ProcurarPorNome(string pokeNome)
        {
            var poke = await _pokemonService.ProcurarPorNome(pokeNome.ToLower().Trim());
            if (poke != null)
                return Ok(poke);

            else
                return BadRequest("Pokemon não existe");
        }
    }
}
