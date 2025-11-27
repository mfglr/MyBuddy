using MediaService.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace MediaService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) =>
            services
                .AddScoped<MongoContext>()
                .AddScoped<IMediaRepository, MediaRepository>();
    }
}
