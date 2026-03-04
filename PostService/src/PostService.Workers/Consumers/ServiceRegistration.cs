using MassTransit;
using MongoDB.Driver;
using PostService.Infrastructure.MongoDB;
using PostService.Workers.Consumers;

namespace PostService.Workers.Consumers
{
    internal class MassTransitOptions
    {
        public required string Host { get; set; }
        public required string VirtualHost { get; set; }
        public required string Password { get; set; }
        public required string UserName { get; set; }
    }

    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<SetPostContentModerationResult.Mapper>()
                .AddSingleton<SetPostMedia.Mapper>()
                .AddMassTransit(
                    x =>
                    {
                        x.AddConsumer<SetPostContentModerationResult.SetPostContentModerationResult>();
                        x.AddConsumer<SetPostMedia.SetPostMedia>();

                        x.AddMongoDbOutbox(o =>
                        {
                            o.QueryDelay = TimeSpan.FromSeconds(1);
                            o.ClientFactory(provider => provider.GetRequiredService<IMongoClient>());
                            o.DatabaseFactory(provider => provider.GetRequiredService<IMongoDatabase>());
                            o.DuplicateDetectionWindow = TimeSpan.FromSeconds(30);
                            o.UseBusOutbox();
                        });

                        x.AddConfigureEndpointsCallback((context, name, cfg) =>
                        {
                            cfg.UseMessageRetry(r =>
                            {
                                r.Handle<MongoCommandException>();
                                r.Handle<ConflictDetectedException>();
                                r.Immediate(5);
                            });

                            cfg.UseMessageRetry(r =>
                            {
                                r.Ignore<MongoCommandException>();
                                r.Ignore<ConflictDetectedException>();
                                r.Intervals(10, 50, 100, 1000, 1000, 1000, 1000, 1000);
                            });

                            cfg.UseMongoDbOutbox(context);
                        });

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host(option.Host, option.VirtualHost, h =>
                            {
                                h.Username(option.UserName);
                                h.Password(option.Password);
                            });

                            cfg.ConfigureEndpoints(context);
                        });

                    }
                );
        }
    }
}
