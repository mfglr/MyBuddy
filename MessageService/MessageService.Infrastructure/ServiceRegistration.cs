using MessageService.Infrastructure.MongoDB;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
            services
                .AddMongoDb();
    }
}
