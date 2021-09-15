using Newtonsoft.Json;
using PocketMonster.Model.Entities;
using PocketMonster.Model.Interfaces.Repository;
using PocketMonster.Model.Interfaces.Services;
using PocketMonster.Sincronizador.ViewModels;
using System;
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
                            t.Id = Guid.NewGuid();
                            t.Nome = separadorLinha[0].Trim().ToLower();
                            t.PokemonCapturados = new List<PokemonTreinador>();
                            for (int i = 1; i < separadorLinha.Count(); i++)
                            {
                                Pokemon poke = await _unitOfWork.PokemonRepository.ProcurarPorNome(separadorLinha[i].Trim().ToLower());
                                PokemonTreinador pk = new()
                                {
                                    IdPokemon = poke.Id
                                };

                                bool existe = validador.PokemonCapturados.Exists(x => x.Pokemon == poke);
                                if (existe == true)
                                    t.PokemonCapturados.Add(pk);
                            }
                            await _unitOfWork.TreinadorRepository.Incluir(t);
                        }
                        else
                        {
                            for (int i = 1; i < separadorLinha.Count(); i++)
                            {
                                Pokemon poke = await _unitOfWork.PokemonRepository.ProcurarPorNome(separadorLinha[i].Trim().ToLower());
                                bool existe = validador.PokemonCapturados.Exists(x => x.Pokemon == poke);

                                if (!existe)
                                {
                                    PokemonTreinador pk = new()
                                    {
                                        IdPokemon = poke.Id
                                    };
                                    validador.PokemonCapturados.Add(pk);
                                }
                                await _unitOfWork.TreinadorRepository.Alterar(validador);
                            }
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
                        Treinador t = await _unitOfWork.TreinadorRepository.ProcurarPorNome(separadorLinha[2].Trim().ToLower());
                        string tipo = separadorLinha[1].Trim().ToLower();

                        if (validador == null)
                        {
                            if (!await _unitOfWork.GinasioRepository.VerificarTreinadorLider(t))
                            {
                                if (await _unitOfWork.TreinadorRepository.QuantidadeTipoPokemon(tipo, t.Nome) > 5)
                                {
                                    Ginasio g = new();
                                    g.Cidade = separadorLinha[0].Trim().ToLower();
                                    g.GymTipo = tipo;
                                    g.GymLider = t;
                                    await _unitOfWork.GinasioRepository.Incluir(g);
                                }
                            }
                        }
                        else
                        {
                            if (!await _unitOfWork.GinasioRepository.VerificarTreinadorLider(t))
                            {
                                if (await _unitOfWork.TreinadorRepository.QuantidadeTipoPokemon(tipo, t.Nome) > 5)
                                {
                                    validador.GymLider = t;
                                    await _unitOfWork.GinasioRepository.Alterar(validador);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}