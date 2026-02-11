using Microsoft.Extensions.DependencyInjection;
using RealtimeService.Domain;

namespace RealtimeService.Infrastructure.MongoDb
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services)
        {
            DbConfiguration.Configure();
            return services
                .AddSingleton<MongoContext>()
                .AddSingleton<IConnectionRepository, ConnectionRepository>();
        }
            
    }
}
