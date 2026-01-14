using Microsoft.Extensions.DependencyInjection;
using UserService.Domain;

namespace UserService.Infrastructure.Mongo
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services)
        {
            return services
                .AddScoped<MongoContext>()
                .AddScoped<IUserRepository, UserRepository>();
        }
    }
}
