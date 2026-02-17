using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudyProgramService.Application;
using StudyProgramService.Domain.StudyProgramAggregate.Abstracts;

namespace StudyProgramService.Infrastructure.PostgreSqlDb
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services)
        {
            services
               .AddDbContext<PostgreSqlContext>(x => x.UseNpgsql("PostgreSql"))
               .AddScoped<IStudyProgramRepository, StudyProgramRepository>()
               .AddScoped<IUnitOfWork, UnitOfWork>();

            DbInitiliazer.Init(services);
            return services;
        }
           
    }
}
