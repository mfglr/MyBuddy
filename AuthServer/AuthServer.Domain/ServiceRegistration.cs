using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.Domain
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services) =>
            services
                .AddScoped<AccountCreatorDomainService>()
                .AddScoped<EmailUpdaterDomainService>()
                .AddScoped<UserNameUpdaterDomainService>();
    }
}
