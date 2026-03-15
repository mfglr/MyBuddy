using MassTransit;
using PostLikeQueryService.Worker.Consumers;
using PostLikeQueryService.Worker.Consumers.UpsertPostUserLike_OnPostDisliked;
using PostLikeQueryService.Worker.Consumers.UpsertPostUserLike_OnPostLiked;
using PostLikeQueryService.Worker.Consumers.UpsertUser_OnNameUpdated;
using PostLikeQueryService.Worker.Consumers.UpsertUser_OnUserCreated;
using PostLikeQueryService.Worker.Consumers.UpsertUser_OnUserMediaSet;
using PostLikeQueryService.Worker.Consumers.UpsertUser_OnUserNameUpdated;

namespace PostLikeQueryService.Worker.Consumers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<UpsertPostUserLike_OnPostDisliked_Mapper>()
                .AddSingleton<UpsertPostUserLike_OnPostLiked_Mapper>()
                .AddSingleton<UpsertUser_OnUserCreated_Mapper>()
                .AddSingleton<UpsertUser_OnUserNameUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnNameUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnUserMediaSet_Mapper>()
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<UpsertPostUserLike_OnPostLiked_PostLikeQueryService>();
                        brc.AddConsumer<UpsertPostUserLike_OnPostDisliked_PostLikeQueryService>();

                        brc.AddConsumer<UpsertUser_OnUserCreated_PostLikeQueryService>();
                        brc.AddConsumer<UpsertUser_OnUserNameUpdated_PostLikeQueryService>();
                        brc.AddConsumer<UpsertUser_OnNameUpdated_PostLikeQueryService>();
                        brc.AddConsumer<UpsertUser_OnUserMediaSet__PostLikeQueryService>();

                        brc.AddConfigureEndpointsCallback((context, name, cfg) =>
                        {
                            cfg.UseMessageRetry(r =>
                            {
                                r.Intervals(10, 50, 100, 1000, 1000, 1000, 1000, 1000);
                            });
                        });

                        brc.UsingRabbitMq((context, rbgc) =>
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
