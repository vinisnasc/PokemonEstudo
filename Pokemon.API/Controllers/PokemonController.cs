using Microsoft.AspNetCore.Mvc;
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
        private readonly SincronizadorService _ss;
        public PokemonController()
        {
            _ss = new SincronizadorService();
        }
        // GET: api/<PokemonController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _ss.Sincronizar();
            return Ok();
        }

        // GET api/<PokemonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PokemonController>
        [HttpPost]
        public void Post()
        {
            
        }

        // PUT api/<PokemonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PokemonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
