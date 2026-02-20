using Microsoft.Extensions.DependencyInjection;

namespace StudyProgramApplicationService.Domain
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services) =>
            services
                .AddScoped<SPACreatorDomainService>();
    }
}
