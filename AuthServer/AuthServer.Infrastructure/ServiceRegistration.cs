using AuthServer.Infrastructure.IdentityFramework;
using AuthServer.Infrastructure.IdentityServer;
using AuthServer.Infrastructure.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddPostgreSql(configuration)
                .AddIdentityFramework()
                .AddAppIdentityServer(configuration);
    }
}
