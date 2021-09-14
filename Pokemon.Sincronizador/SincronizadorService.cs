using Newtonsoft.Json;
using PocketMonster.Model.Entities;
using PocketMonster.Model.Interfaces.Repository;
using PocketMonster.Model.Interfaces.Services;
using PocketMonster.Sincronizador.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PocketMonster.Sincronizador
{
    public class SincronizadorService : ISincronizadorService
    {
        private const string URL_POKEMON = "https://pokeapi.co/api/v2/pokemon/";
        private readonly IUnitOfWork _unitOfWork;

        public SincronizadorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SincronizarPokemon()
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
                var poskemonCompare = await _unitOfWork.PokemonRepository.SelecionarPorPokedex(poskemon.id);
                if (poskemonCompare == null)
                {
                    Pokemon novoPoke = new();
                    novoPoke.RegistroPokedex = poskemon.id;
                    novoPoke.Nome = poskemon.species.name;
                    novoPoke.Tipo1 = poskemon.types[0].type.name;
                    if (poskemon.types.Count == 2)
                        novoPoke.Tipo2 = poskemon.types[1].type.name;
                    await _unitOfWork.PokemonRepository.Incluir(novoPoke);
                }
                else
                {
                    poskemonCompare.Nome = poskemon.species.name;
                    poskemonCompare.RegistroPokedex = poskemon.id;
                    poskemonCompare.Tipo1 = poskemon.types[0].type.name;
                    if (poskemon.types.Count == 2)
                        poskemonCompare.Tipo2 = poskemon.types[1].type.name;
                    await _unitOfWork.PokemonRepository.Alterar(poskemonCompare);
                }
                count++;
                endpoint = URL_POKEMON + count + "/";
                retornoTask = client.GetAsync(endpoint).Result;
            }
        }

        public async Task SincronizarTreinadores(string endereco)
        {
            string[] lines = File.ReadAllLines(endereco);

            using (FileStream fs = new(endereco, FileMode.Open))
            {
                using (StreamReader sr = new(fs))
                {
                    foreach (string linha in lines)
                    {
                        string[] separadorLinha = linha.Split(",");
                        Treinador validador = await _unitOfWork.TreinadorRepository.ProcurarPorNome(separadorLinha[0].Trim().ToLower());

                        if (validador == null)
                        {
                            Treinador t = new();
                            t.Nome = separadorLinha[0].Trim().ToLower();
                            for (int i = 1; i < separadorLinha.Count(); i++)
                            {
                                Pokemon poke = await _unitOfWork.PokemonRepository.ProcurarPorNome(separadorLinha[i].Trim().ToLower());
                                t.Pokemons.Add(poke);
                            }
                            await _unitOfWork.TreinadorRepository.Incluir(t);
                        }
                    }
                }
            }
        }

        public async Task SincronizarGinasios(string endereco)
        {
            string[] lines = File.ReadAllLines(endereco);

            using (FileStream fs = new(endereco, FileMode.Open))
            {
                using (StreamReader sr = new(fs))
                {
                    foreach (string linha in lines)
                    {
                        string[] separadorLinha = linha.Split(",");
                        Ginasio validador = await _unitOfWork.GinasioRepository.ProcurarPorNome(separadorLinha[0].Trim().ToLower());

                        if (validador == null)
                        {
                            Ginasio g = new();
                            g.Cidade = separadorLinha[0].Trim().ToLower();
                            g.GymTipo = separadorLinha[1].Trim().ToLower();
                            g.GymLider = await _unitOfWork.TreinadorRepository.ProcurarPorNome(separadorLinha[2].Trim().ToLower());
                            await _unitOfWork.GinasioRepository.Incluir(g);
                        }
                    }
                }
            }
        }
    }
}