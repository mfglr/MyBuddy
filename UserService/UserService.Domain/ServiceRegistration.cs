using Microsoft.Extensions.DependencyInjection;

namespace UserService.Domain
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services) =>
            services
                .AddScoped<UserNameUpdaterDomainService>();
    }
}
