using Microsoft.Extensions.DependencyInjection;

namespace StudyProgramInviteService.Domain
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services) =>
            services.AddScoped<SPICreatorDomainService>();
    }
}
