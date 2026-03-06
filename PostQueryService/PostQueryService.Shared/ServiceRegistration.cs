using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostQueryService.Shared.PostgreSql;

namespace PostQueryService.Shared
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddShared(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddPostgreSql(configuration);
    }
}
