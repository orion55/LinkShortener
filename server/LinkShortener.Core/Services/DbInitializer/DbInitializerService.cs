using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LinkShortener.Db.Entities.Core;
using LinkShortener.Db.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LinkShortener.Core.Services.DbInitializer
{
    public class DbInitializerService: IDbInitializerService
    {
        private readonly ILogger<DbInitializerService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        
        public DbInitializerService(ILogger<DbInitializerService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }
        
        public async Task InitializeAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Migrating database");
            using var scope = _serviceScopeFactory.CreateScope();
            await using var dbContext = scope.ServiceProvider.GetRequiredService<LinkDbContext>();
            await dbContext.Database.MigrateAsync(cancellationToken);
            _logger.LogInformation("Database migrated");
        }

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Seeding database");
            using var scope = _serviceScopeFactory.CreateScope();
            await using var dbContext = scope.ServiceProvider.GetRequiredService<LinkDbContext>();
            await SeedLinks(dbContext, cancellationToken);
            _logger.LogInformation("Seeded database");
        }

        private async Task SeedLinks(LinkDbContext context, CancellationToken cancellationToken)
        {
            if (!context.Links.Any())
            {
                var link = new Link
                {
                    From = "www.ya.ru",
                    Clicks = 0,
                    DateCreated = DateTime.Now
                };
                await context.Links.AddAsync(link, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}