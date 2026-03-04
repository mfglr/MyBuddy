using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PostService.Application;
using PostService.Domain;

namespace PostService.Infrastructure.MongoDB
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoClient>(new MongoClient(configuration["MongoOptions:ConnectionString"]));
            services.AddSingleton(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(configuration["MongoOptions:DatabaseName"]);
            });
            services.AddScoped<MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPostRepository, PostRepository>();
            return services;
        }
    }
}
