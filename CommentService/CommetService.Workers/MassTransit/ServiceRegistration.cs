using CommetService.Workers.MassTransit;
using CommetService.Workers.MassTransit.Consumers;
using MassTransit;
using MongoDB.Driver;

namespace CommetService.Workers.MassTransit
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services.AddMassTransit(
                x =>
                {
                    x.AddConsumer<SetModerationResult_OnCommentContentClassified_CommentService>();
                    x.AddConsumer<DeleteReplies_OnCommentDeleted_CommentService>();
                    x.AddConsumer<DeletePostComments_OnPostDeleted_ComentService>();
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
                            r.Intervals(10, 50, 100, 1000, 1000, 1000, 1000, 1000);
                        });

                        cfg.UseMongoDbOutbox(context);
                    });


                    x.UsingRabbitMq((context, rbgc) =>
                    {
                        rbgc.Host(
                            option.Host,
                            option.VirtualHost,
                            rhc =>
                            {
                                rhc.Username(option.UserName);
                                rhc.Password(option.Password);
                            }
                        );
                        rbgc.ConfigureEndpoints(context);
                    });
                }
            );
        }
            
    }
}
