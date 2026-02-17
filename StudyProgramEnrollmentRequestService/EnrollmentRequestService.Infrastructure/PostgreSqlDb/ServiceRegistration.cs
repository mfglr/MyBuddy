using EnrollmentRequestService.Application;
using EnrollmentRequestService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnrollmentRequestService.Infrastructure.PostgreSqlDb
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services, IConfiguration configuration) =>
            services
               .AddDbContext<PostgreSqlContext>(x => x.UseNpgsql(configuration.GetConnectionString("PostgreSql")))
               .AddScoped<IEnrollmentRequestRepository, EnrollmentRequestRepository>()
               .AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
