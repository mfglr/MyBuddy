using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Infrastructure.Keycloak;
using UserService.Infrastructure.Mongo;

namespace UserService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddKeycloak(configuration)
                .AddMongoDb();
    }
}
