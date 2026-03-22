using CommentQueryService.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CommentQueryService.Infrastructure.MongoDB
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMongoDB(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<IMongoClient>(new MongoClient(configuration["MongoOptions:ConnectionString"]))
                .AddSingleton(sp =>
                {
                    var client = sp.GetRequiredService<IMongoClient>();
                    return client.GetDatabase(configuration["MongoOptions:DatabaseName"]);
                })
                .AddScoped<MongoContext>()
                .AddScoped<ICommentProjectionRepository, CommentProjectionRepository>();
    }
}
