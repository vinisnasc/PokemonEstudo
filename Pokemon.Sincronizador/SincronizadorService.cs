using Newtonsoft.Json;
using PocketMonster.Data.Dao;
using PocketMonster.Model;
using PocketMonster.Model.Interfaces.Daos;
using PocketMonster.Model.Interfaces.Services;
using PocketMonster.Sincronizador.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PocketMonster.Sincronizador
{
    public class SincronizadorService : ISincronizadorService
    {
        private const string URL_POKEMON = "https://pokeapi.co/api/v2/pokemon/";
        private readonly IPokemonDao _pokemonDao;

        public SincronizadorService(IPokemonDao pokemonDao)
        {
            _pokemonDao = pokemonDao;
        }

        public async Task Sincronizar()
        {
            List<Task> tasks = new();

            await SincronizarPokemon();
        }

        private async Task SincronizarPokemon()
        {

            List<PokeDetailsViewModel> lista = new();

            var handler = new HttpClientHandler();
            var client = new HttpClient(handler);
            var retornoTask = new HttpResponseMessage();

            int count = 1;
            var endpoint = URL_POKEMON + count + "/";
            retornoTask = client.GetAsync(endpoint).Result;

            while (retornoTask.IsSuccessStatusCode)
            {
                var contretorn = await retornoTask.Content.ReadAsStringAsync();
                var poskemon = JsonConvert.DeserializeObject<PokeDetailsViewModel>(contretorn);
                lista.Add(poskemon);
                count++;
                endpoint = URL_POKEMON + count + "/";
                retornoTask = client.GetAsync(endpoint).Result;
            }

            List<Pokemon> listaPokemon = new();
            foreach(var poke in lista)
            {
                Pokemon pokemon = new();
                pokemon.IdPokemon = poke.id;
                pokemon.Nome = poke.species.name;
                pokemon.Tipo1 = poke.types[0].type.name;
                if (poke.types.Count == 2)
                    pokemon.Tipo2 = poke.types[1].type.name;

                listaPokemon.Add(pokemon);
            }

            await _pokemonDao.InserirPokemon(listaPokemon);
        }
    }
}
