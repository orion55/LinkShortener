using System;
using LinkShortener.Db.Entities.Core;
using LinkShortener.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LinkShortener.Db.Infrastructure
{
    public class LinkDbContext: DbContext
    {
        public LinkDbContext(DbContextOptions<LinkDbContext> options) : base(options)
        {
        }
        
        public DbSet<Product> Product { get; set; }
        public DbSet<Link> Links { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (optionsBuilder.IsConfigured) return;

            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ??
                                  Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }
        
    }
}