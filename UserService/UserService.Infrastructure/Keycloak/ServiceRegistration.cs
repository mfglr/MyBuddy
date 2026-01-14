using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application;

namespace UserService.Infrastructure.Keycloak
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddKeycloak(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection("AuthOptions").Get<KeycloakAuthOptions>()!;

            return services
                .AddSingleton(option)
                .AddScoped<KeycloakAccessTokenProvider>()
                .AddScoped<IAuthService, KeycloakAuthService>();
        }

    }
}
