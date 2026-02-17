using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyProgramService.Application;
using StudyProgramService.Domain;

namespace StudyProgramService.Infrastructure.PostgreSqlDb
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services,IConfiguration configuration)
        {
            services
               .AddDbContext<PostgreSqlContext>(x => x.UseNpgsql(configuration.GetConnectionString("PostgreSql")))
               .AddScoped<IStudyProgramRepository, StudyProgramRepository>()
               .AddScoped<IUnitOfWork, UnitOfWork>();
            DbInitiliazer.Init(services);
            return services;
        }
           
    }
}
