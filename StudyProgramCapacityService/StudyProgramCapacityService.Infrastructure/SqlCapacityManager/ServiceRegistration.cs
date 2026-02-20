using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyProgramCapacityService.Application;

namespace StudyProgramCapacityService.Infrastructure.SqlCapacityManager
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddSqlCapacityManager(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<SqlContext>(x => x.UseNpgsql(configuration.GetConnectionString("PostgreSql")))
                .AddScoped<ISPCManager, SqlSPCManager>();
    }
}
