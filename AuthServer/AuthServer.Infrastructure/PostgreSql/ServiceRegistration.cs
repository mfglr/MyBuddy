using AuthServer.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.Infrastructure.PostgreSql
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services,IConfiguration configuration) =>
            services
                .AddDbContext<SqlContext>(x => x.UseNpgsql(configuration.GetConnectionString("PostgreSql")))
                .AddScoped<IUnitOfWork, UnitOfWork>();  
    }
}
