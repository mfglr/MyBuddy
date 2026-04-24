using CommentLikeQueryService.Domain.CommentLikeAggregate;
using CommentLikeQueryService.Domain.UserAggregate;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CommentLikeQueryService.Infrastructure.MongoDB
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services,IConfiguration configuration)
        {
            return services
                .AddSingleton<IMongoClient>(new MongoClient(configuration["MongoOptions:ConnectionString"]))
                .AddSingleton(sp =>
                {
                    var client = sp.GetRequiredService<IMongoClient>();
                    return client.GetDatabase(configuration["MongoOptions:DatabaseName"]);
                })
                .AddScoped<MongoContext>()
                .AddScoped<ICommentLikeRepository, CommentLikeProjectionRepository>()
                .AddScoped<IUserRepository, UserRepository>();
        }
            
    }
}
