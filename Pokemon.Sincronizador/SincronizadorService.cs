using PocketMonster.Data.Dao;
using PocketMonster.Model;
using PocketMonster.Sincronizador.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PocketMonster.Sincronizador
{
    public class SincronizadorService
    {
        private const string URL_POKEMON = "https://pokeapi.co/api/v2/pokemon/";

        public async Task Sincronizar()
        {
            List<Task> tasks = new();

            await SincronizarPokemon();
        }

        private async Task SincronizarPokemon()
        {
            HttpClient httpClient = new();
            List<PokemonViewModel> lista = new();
            ResultadoAPI<PokemonViewModel> resultadoAPI = null;

            int count = 0;

            do
            {
                resultadoAPI = await httpClient.GetFromJsonAsync<ResultadoAPI<PokemonViewModel>>(resultadoAPI?.Next ?? URL_POKEMON);
                lista.AddRange(resultadoAPI.Results);
                count++;
            } while (count < 3);

            var pokemon = lista.Select(item => new Pokemon
            {
                IdPokemon = item.IdPokemon,
                Nome = item.Name,
            }).ToList();

            int countt = 0;
            ResultadoAPI<PokeDetailsViewModel> resultadoAPII = null;
            List<PokeDetailsViewModel> lista2 = new();
            while (countt < lista.Count)
            {
                HttpClient httpClient1 = new();
                resultadoAPII = await httpClient1.GetFromJsonAsync<ResultadoAPI<PokeDetailsViewModel>>(lista[0].Url);
                lista2.AddRange(resultadoAPII.Results);
                count++;
            }

            using (PokemonDao dao = new())
                await dao.InserirPokemon(pokemon);
        }
    }
}
