using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocketMonster.Data.ContextDB;
using PocketMonster.Data.Repository;
using PocketMonster.Model.Interfaces.Repository;
using PocketMonster.Model.Interfaces.Services;
using PocketMonster.Service;
using PocketMonster.Sincronizador;
using System;

namespace PocketMonster.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString, IConfiguration configuration)
        {
            // Context 
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            // Services
            services.AddScoped<ISincronizadorService, SincronizadorService>();
            services.AddScoped<ITreinadorService, TreinadorService>();
            services.AddScoped<IPokemonService, PokemonService>();

            // Repository
            services.AddScoped<IPokemonRepository, PokemonRepository>();
            services.AddScoped<ITreinadorRepository, TreinadorRepository>();
            services.AddScoped<IGinasioRepository, GinasioRepository>();

            // Unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
