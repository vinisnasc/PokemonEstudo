using Microsoft.AspNetCore.Mvc;
using PocketMonster.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PocketMonster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SincronizadorController : ControllerBase
    {
        private readonly ISincronizadorService _sincronizadorService;
        
        public SincronizadorController(ISincronizadorService sincronizadorService)
        {
            _sincronizadorService = sincronizadorService;
        }

        /// <summary>
        /// Sincroniza automaticamente os pokemons da API do pokeapi.co
        /// </summary>
        /// <returns></returns>
        [HttpGet("SincronizarPokemon")]
        public async Task<IActionResult> GetPokemon()
        {
            await _sincronizadorService.SincronizarPokemon();
            return Ok();
        }

        /// <summary>
        /// Importa localmente os dados dos treinadores. Necessario arquivo csv, com nome e pokemons separados por virgula
        /// </summary>
        /// <param name="endereco">Coloque aqui o endereço de onde esta o arquivo com o nome do arquivo</param>
        /// <returns></returns>
        [HttpGet("ImportarTreinadores")]
        public async Task<IActionResult> GetTreinadores(string endereco)
        {
            await _sincronizadorService.SincronizarTreinadores(endereco);
            return Ok();
        }

        /// <summary>
        /// Importa localmente os dados dos ginasios. Necessario arquivo csv, com cidade, tipo e lider separados por virgula
        /// </summary>
        /// <param name="endereco">Coloque aqui o endereço de onde esta o arquivo com o nome do arquivo</param>
        /// <returns></returns>
        [HttpGet("ImportarGinasios")]
        public async Task<IActionResult> GetGinasios(string endereco)
        {
            await _sincronizadorService.SincronizarGinasios(endereco);
            return Ok();
        }
    }
}
