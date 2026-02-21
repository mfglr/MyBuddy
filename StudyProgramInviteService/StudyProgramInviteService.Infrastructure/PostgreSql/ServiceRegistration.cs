using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyProgramInviteService.Application;
using StudyProgramInviteService.Domain;

namespace StudyProgramInviteService.Infrastructure.PostgreSql
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<SqlContext>(x => x.UseNpgsql(configuration.GetConnectionString("PostgreSql")))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<ISPIRepository, SPIRepository>();
    }
}
