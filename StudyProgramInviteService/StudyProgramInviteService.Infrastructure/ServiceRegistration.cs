using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyProgramInviteService.Infrastructure.PostgreSql;

namespace StudyProgramInviteService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddPostgreSql(configuration);
    }
}
