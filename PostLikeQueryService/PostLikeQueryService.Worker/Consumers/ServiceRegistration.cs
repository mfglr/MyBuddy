using MassTransit;
using PostLikeQueryService.Worker.Consumers;
using PostLikeQueryService.Worker.Consumers.UpsertPostUserLike_OnPostDisliked;
using PostLikeQueryService.Worker.Consumers.UpsertPostUserLike_OnPostLiked;
using PostLikeQueryService.Worker.Consumers.UpsertUser_OnAccountCreated;
using PostLikeQueryService.Worker.Consumers.UpsertUser_OnAccountMediaSet;
using PostLikeQueryService.Worker.Consumers.UpsertUser_OnAccountNameUpdated;
using PostLikeQueryService.Worker.Consumers.UpsertUser_OnAccountUserNameUpdated;

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
                .AddSingleton<UpsertUser_OnAccountCreated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountUserNameUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountNameUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountMediaSet_Mapper>()
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<UpsertPostUserLike_OnPostLiked_PostLikeQueryService>();
                        brc.AddConsumer<UpsertPostUserLike_OnPostDisliked_PostLikeQueryService>();

                        brc.AddConsumer<UpsertUser_OnAccountCreated_PostLikeQueryService>();
                        brc.AddConsumer<UpsertUser_OnAccountUserNameUpdated_PostLikeQueryService>();
                        brc.AddConsumer<UpsertUser_OnAccountNameUpdated_PostLikeQueryService>();
                        brc.AddConsumer<UpsertUser_OnAccountMediaSet__PostLikeQueryService>();

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
