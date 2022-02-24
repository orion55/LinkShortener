using System.Threading.Tasks;
using LinkShortener.Core.Services.DbInitializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LinkShortener.Core.Infrastructure
{
    public static class DbContextExtensions
    {
        public static async Task InitializeDatabaseAsync(this IApplicationBuilder applicationBuilder)
        {
            var serviceScopeFactory = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using var scope = serviceScopeFactory.CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializerService>();
            await initializer.InitializeAsync();
            await initializer.SeedAsync();
        }
    }
}