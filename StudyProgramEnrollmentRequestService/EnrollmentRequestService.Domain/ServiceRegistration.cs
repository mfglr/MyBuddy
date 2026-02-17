using Microsoft.Extensions.DependencyInjection;

namespace EnrollmentRequestService.Domain
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services) =>
            services
                .AddScoped<EnrollmentRequestCreatorDomainService>();
    }
}
