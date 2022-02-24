using System.Threading;
using System.Threading.Tasks;

namespace LinkShortener.Core.Services.DbInitializer
{
    public interface IDbInitializerService
    {
        Task InitializeAsync(CancellationToken cancellationToken = default);
        Task SeedAsync(CancellationToken cancellationToken = default);
    }
}