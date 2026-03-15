using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostLikeQueryService.Shared.PostgreSql;

namespace PostLikeQueryService.Shared
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddShared(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddPostgreSql(configuration);
    }
}
