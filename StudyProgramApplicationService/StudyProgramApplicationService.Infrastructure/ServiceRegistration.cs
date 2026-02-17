using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyProgramApplicationService.Infrastructure.PostgreSqlDb;

namespace StudyProgramApplicationService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration) =>
            services.AddPostgreSql(configuration);
    }
}
