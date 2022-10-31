using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocketMonster.API.Extensoes;
using PocketMonster.Data.ContextDB;

namespace PocketMonster.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer("Server=DESKTOP-R9JFMSC\\SQLEXPRESS;Database=PKMNIdentity;Integrated Security=True;Connect Timeout=30"));

            services.AddDefaultIdentity<IdentityUser>()
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<IdentityContext>()
               .AddErrorDescriber<IdentityMensagensPortugues>()
               .AddDefaultTokenProviders();
            
            return services;
        }
    }
}