using AuthServer.Application;

namespace AuthServer.CleanUp.Auth
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddAuth(this IServiceCollection services) =>
            services.AddSingleton<IAuthService, CleanupAuthService>();
    }
}
