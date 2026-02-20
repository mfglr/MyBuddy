using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyProgramCapacityService.Infrastructure.SqlCapacityManager;

namespace StudyProgramCapacityService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration) =>
            services
                .AddSqlCapacityManager(configuration);

    }
}
