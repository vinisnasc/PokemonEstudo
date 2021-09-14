using Microsoft.EntityFrameworkCore;
using PocketMonster.Model.Entities;
using System.Reflection;

namespace PocketMonster.Data.ContextDB
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Treinador> Treinadores { get; set; }
        public DbSet<Ginasio> Ginasios { get; set; }
        public DbSet<PokemonTreinador> PokemonTreinador { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
