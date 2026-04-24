using AuthServer.Application;

namespace AuthServer.Worker.Auth
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddAuth(this IServiceCollection services) =>
            services.AddSingleton<IAuthService, WorkerAuthService>();
    }
}
