using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostService.Application;
using PostService.Domain;

namespace PostService.Infrastructure.PostgreSql
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<SqlContext>(x => x.UseNpgsql(configuration.GetConnectionString("PostgreSql")))
                .AddScoped<IPostRepository, PostRepository>()
                .AddScoped<IUnitOfWork,UnitOfWork>();
            DbInitiliazer.Init(services);
            return services;
        }
    }
}
