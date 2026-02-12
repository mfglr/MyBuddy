using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostLikeService.Domain;

namespace PostLikeService.Infrastructure.MongoDb
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services,IConfiguration configuration)
        {
            DbConfiguration.Configure();
            var context = new MongoContext(configuration);
            
            return services
                .AddSingleton(context)
                .AddSingleton<IPostLikeRepository, PostLikeRepository>();
        }
            
    }
}
