using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyProgramApplicationService.Application;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Infrastructure.PostgreSqlDb
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services, IConfiguration configuration) =>
            services
               .AddDbContext<PostgreSqlContext>(x => x.UseNpgsql(configuration.GetConnectionString("PostgreSql")))
               .AddScoped<ISPARepository, SPARepository>()
               .AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
