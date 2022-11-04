using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using PocketMonster.API.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace PocketMonster.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pokemon.API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddIdentityConfig(Configuration);
            services.RegisterServices(Configuration);

            /* Cors serve para facilitar a comunicação externa, caso o projeto seja aberto para outros sites, é necessario a implementação
            services.AddCors(opt => 
            {
                opt.AddPolicy("Development", bdr => bdr.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod().AllowCredentials());
                opt.AddPolicy("Production", bdr => bdr.WithMethods("GET")
                                                      .WithOrigins("http://exemplo.com")
                                                      .SetIsOriginAllowedToAllowWildcardSubdomains()
                                                      .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                                                      .AllowAnyHeader());
            }
            );
            */
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pokemon.API v1"));
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
