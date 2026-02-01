using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostQueryService.Application;
using PostQueryService.Domain.PostDomain;
using PostQueryService.Domain.UserDomain;
using PostQueryService.Infrastructure.MsSql.QuerRepositories;

namespace PostQueryService.Infrastructure.MsSql
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMsSql(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<MsSqlContext>(x => x.UseSqlServer(configuration.GetConnectionString("SqlServer")))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IPostRepository, PostRepository>()
                .AddQueryRepositories();
            return services;
        }

        private static void InitDb(IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetService<MsSqlContext>()!;
            context.Database.Migrate();
        }
    }
}
