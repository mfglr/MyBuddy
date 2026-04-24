using CommentLikeQueryService.Worker.MassTransit;
using CommentLikeQueryService.Worker.MassTransit.Consumers.CreateCommentLike_OnCommentLiked;
using CommentLikeQueryService.Worker.MassTransit.Consumers.DeleteCommentLike_OnCommentDisliked;
using CommentLikeQueryService.Worker.MassTransit.Consumers.UpsertUser_OnAccountCreated;
using CommentLikeQueryService.Worker.MassTransit.Consumers.UpsertUser_OnAccountMediaCreated;
using CommentLikeQueryService.Worker.MassTransit.Consumers.UpsertUser_OnAccountMediaSet;
using CommentLikeQueryService.Worker.MassTransit.Consumers.UpsertUser_OnAccountNameUpdated;
using CommentLikeQueryService.Worker.MassTransit.Consumers.UpsertUser_OnAccountUserNameUpdated;
using MassTransit;

namespace CommentLikeQueryService.Worker.MassTransit
{
    internal static class ServiceRegistrationExtens
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<CreateCommentLike_OnCommentLiked_Mapper>()
                .AddSingleton<DeleteCommentLike_OnCommentDisliked_Mapper>()

                .AddSingleton<UpsertUser_OnAccountCreated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountNameUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountUserNameUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountMediaCreated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountMediaSet_Mapper>()
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<CreateCommentLike_OnCommentLiked_CommentLikeQueryService>();
                        brc.AddConsumer<DeleteCommentLike_OnCommentDisliked_CommentLikeQueryService>();

                        brc.AddConsumer<UpsertUser_OnAccountCreated_CommentLikeQueryService>();
                        brc.AddConsumer<UpsertUser_OnAccountNameUpdated_CommentLikeQueryService>();
                        brc.AddConsumer<UpsertUser_OnAccountUserNameUpdated_CommentLikeQueryService>();
                        brc.AddConsumer<UpsertUser_OnAccountMediaCreated_CommentLikeQueryService>();
                        brc.AddConsumer<UpsertUser_OnAccountMediaSet_CommentLikeQueryService>();

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
