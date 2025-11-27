using BlobService.Application;
using Microsoft.Extensions.DependencyInjection;

namespace BlobService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) =>
            services
                .AddSingleton<PathFinder>()
                .AddSingleton<UniqNameGenerator>()
                .AddSingleton<IContainerService, LocalContainerService>()
                .AddSingleton<IBlobService, LocalBlobService>();

    }
}
