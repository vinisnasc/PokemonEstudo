using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PocketMonster.Model.Interfaces.Services;
using System.Threading.Tasks;

namespace PocketMonster.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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