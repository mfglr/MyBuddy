using Microsoft.Extensions.DependencyInjection;
using StudyProgramService.Infrastructure.PostgreSqlDb;

namespace StudyProgramService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service) =>
            service
                .AddPostgreSql();
    }
}
