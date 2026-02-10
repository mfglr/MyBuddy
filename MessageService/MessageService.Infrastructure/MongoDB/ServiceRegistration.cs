using MessageService.Domain.MessageAggregate;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Infrastructure.MongoDB
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services)
        {
            DbConfiguration.Configure();
            return services
                .AddSingleton<MongoContext>()
                .AddSingleton<IMessageRepository, MessageRepository>();
        }
            
    }
}
