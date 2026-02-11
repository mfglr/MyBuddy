using MessageService.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Infrastructure.MongoDb
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services,IConfiguration configuration)
        {
            DbConfiguration.Configure();

            var context = new MongoContext(configuration);
            MongoDbBootstrap.EnsureIndexes(context);
            
            return services
                .AddSingleton(context)
                .AddSingleton<IMessageRepository, MessageRepository>();
        }
            
    }
}
