using HeroBattle.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HeroBattle.Infrastructure.Context
{
    public class HeroBattleDbContext : DbContext
    {
        public HeroBattleDbContext(DbContextOptions<HeroBattleDbContext> options) : base(options)
        {

        }

        public DbSet<Arena> Arenas { get; set; }
    }

    public class HeroBattleDbContextFactory : IDesignTimeDbContextFactory<HeroBattleDbContext>
    {
        public HeroBattleDbContext CreateDbContext(string[] args)
        {
            // Build configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DevoraLime"))
                .AddJsonFile("appsettings.json")
                .Build();

            // Create DbContextOptions
            var builder = new DbContextOptionsBuilder<HeroBattleDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new HeroBattleDbContext(builder.Options);
        }
    }
}
