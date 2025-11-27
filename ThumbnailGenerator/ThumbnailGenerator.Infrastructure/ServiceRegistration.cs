using Microsoft.Extensions.DependencyInjection;
using ThumbnailGenerator.Application;

namespace ThumbnailGenerator.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) =>
            services
                .AddSingleton<IBlobService,LocalBlobService>()
                .AddScoped<IThumbnailGenerator, ThumbnailGenerator>();

    }
}
