using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Infrastructure.BlobService;
using UserService.Infrastructure.Keycloak;
using UserService.Infrastructure.MongoDB;

namespace UserService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddMongoDB(configuration)
                .AddBlobService(configuration)
                .AddKeycloak(configuration);
    }
}
