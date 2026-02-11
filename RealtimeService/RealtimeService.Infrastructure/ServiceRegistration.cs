using Microsoft.Extensions.DependencyInjection;
using RealtimeService.Infrastructure.MongoDb;

namespace RealtimeService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
            services.AddMongoDb();
    }
}
