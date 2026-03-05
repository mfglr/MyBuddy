using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using UserQueryService.Shared.Model;

namespace UserQueryService.Shared.MongoDB
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
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
