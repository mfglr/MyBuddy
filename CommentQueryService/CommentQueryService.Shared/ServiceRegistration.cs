using CommentQueryService.Shared.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommentQueryService.Shared
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddShared(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddPostgreSql(configuration);
    }
}
