using EnrollmentRequestService.Infrastructure.PostgreSqlDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnrollmentRequestService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration) =>
            services.AddPostgreSql(configuration);
    }
}
