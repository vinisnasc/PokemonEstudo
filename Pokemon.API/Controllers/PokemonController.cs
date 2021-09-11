using Microsoft.AspNetCore.Mvc;
using PocketMonster.Model.Interfaces.Services;
using PocketMonster.Sincronizador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PocketMonster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly ISincronizadorService _sincronizadorService;
        public PokemonController(ISincronizadorService sincronizadorService)
        {
            _sincronizadorService = sincronizadorService;
        }
        

        [HttpGet("Sincronizar tudo")]
        public async Task<IActionResult> Get()
        {
            await _sincronizadorService.Sincronizar();
            return Ok();
        }
    }
}
