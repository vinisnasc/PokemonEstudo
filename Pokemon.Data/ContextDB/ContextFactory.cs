using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PocketMonster.Data.ContextDB
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Pokemon.API"))
                                .AddJsonFile("appsettings.Development.json")
                                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<Context>();
            var connectionString = "Server=DESKTOP-R9JFMSC\\SQLEXPRESS;Database=PKMNDataBase;Integrated Security=True;Connect Timeout=30";
            dbContextBuilder.UseSqlServer(connectionString);

            return new Context(dbContextBuilder.Options);
        }
    }
}
