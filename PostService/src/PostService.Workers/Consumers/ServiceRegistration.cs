using MassTransit;
using MongoDB.Driver;
using PostService.Infrastructure.MongoDB;
using PostService.Workers.Consumers;
using PostService.Workers.Consumers.DeleteUserPosts_OnAccountDeleted;
using PostService.Workers.Consumers.SetPostContentModerationResult;
using PostService.Workers.Consumers.SetPostMedia;

namespace PostService.Workers.Consumers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<SetPostContentModerationResult_PostContentClassified_Mapper>()
                .AddSingleton<SetPostMedia_OnMediaPreprocessingCompleted_Mapper>()
                .AddMassTransit(
                    x =>
                    {
                        x.AddConsumer<SetPostContentModerationResult_PostContentClassified_PostService>();
                        x.AddConsumer<SetPostMedia_OnMediaPreprocessingCompleted_PostService>();
                        x.AddConsumer<DeleteUserPosts_OnAccountDeleted_PostService>();
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
