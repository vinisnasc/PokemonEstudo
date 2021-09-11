using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocketMonster.Data.Dao;
using PocketMonster.Model.Interfaces.Daos;
using PocketMonster.Model.Interfaces.Services;
using PocketMonster.Sincronizador;
using System;

namespace PocketMonster.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString, IConfiguration configuration)
        {
            // Services
            services.AddScoped<ISincronizadorService, SincronizadorService>();

            // Daos
            services.AddScoped<IPokemonDao, PokemonDao>();
        }
    }
}
