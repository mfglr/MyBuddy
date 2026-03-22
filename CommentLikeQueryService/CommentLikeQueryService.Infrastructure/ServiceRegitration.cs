using CommentLikeQueryService.Infrastructure.MongoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommentLikeQueryService.Infrastructure
{
    public static class ServiceRegitration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
            services.AddMongoDb(configuration);
    }
}
