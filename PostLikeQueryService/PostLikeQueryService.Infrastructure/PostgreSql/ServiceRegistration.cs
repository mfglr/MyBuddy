using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostLikeQueryService.Application;
using PostLikeQueryService.Domain.PostLikeAggregate;
using PostLikeQueryService.Domain.UserAggregate;

namespace PostLikeQueryService.Infrastructure.PostgreSql
{
    internal static  class ServiceRegistration
    {
        public static IServiceCollection AddPosgreSql(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton<PostLikeResponseMapper>()
                .AddDbContext<SqlContext>(x => x.UseNpgsql(configuration.GetConnectionString("PostgreSql")))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IPostLikeQueryRepository, PostLikeQueryRepository>()
                .AddScoped<IPostLikeRepository, PostLikeRepository>()
                .AddScoped<IUnitOfWork,UnitOfWork>();
            return services;
        }
    }
}
