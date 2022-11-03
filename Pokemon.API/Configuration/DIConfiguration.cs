using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocketMonster.API.Extensoes;
using PocketMonster.Data.ContextDB;
using PocketMonster.Data.Repository;
using PocketMonster.Model.Interfaces;
using PocketMonster.Model.Interfaces.Repository;
using PocketMonster.Model.Interfaces.Services;
using PocketMonster.Service;
using PocketMonster.Sincronizador;

namespace PocketMonster.API.Configuration
{
    public static class DIConfiguration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Context 
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQL"));
            });

            // Services
            services.AddScoped<ISincronizadorService, SincronizadorService>();
            services.AddScoped<ITreinadorService, TreinadorService>();
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<IGinasioService, GinasioService>();

            // Repository
            services.AddScoped<IPokemonRepository, PokemonRepository>();
            services.AddScoped<ITreinadorRepository, TreinadorRepository>();
            services.AddScoped<IGinasioRepository, GinasioRepository>();

            // Unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Identity Extension
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            return services;
        }
    }
}