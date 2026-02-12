using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostLikeService.Infrastructure.MongoDb;

namespace PostLikeService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddMongoDb(configuration);
    }
}
