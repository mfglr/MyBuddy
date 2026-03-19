using CommentQueryService.Worker.MassTransit;
using CommentQueryService.Worker.MassTransit.Consumers.DecreaseChildCount_OnCommentDeleted;
using CommentQueryService.Worker.MassTransit.Consumers.DecreaseLikeCount_OnCommentDisliked;
using CommentQueryService.Worker.MassTransit.Consumers.IncreaseChildCount_OnCommentCreated;
using CommentQueryService.Worker.MassTransit.Consumers.IncreaseLikeCount_OnCommentLiked;
using CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnCommentCreated;
using CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnCommentDeleted;
using CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnContentUpdated;
using CommentQueryService.Worker.MassTransit.Consumers.UpsertComment_OnModerationResultSet;
using CommentQueryService.Worker.MassTransit.Consumers.UpsertUser_OnAccountCreated;
using CommentQueryService.Worker.MassTransit.Consumers.UpsertUser_OnAccountMediaSet;
using CommentQueryService.Worker.MassTransit.Consumers.UpsertUser_OnAccountNameUpdated;
using CommentQueryService.Worker.MassTransit.Consumers.UpsertUserOnAccountUserNameUpdated;
using CommentQueryService.Worker.MassTransit.Consumers.UpsertUserOnUserCreated;
using MassTransit;

namespace CommentQueryService.Worker.MassTransit
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<UpsertComment_OnCommentCreated_Mapper>()
                .AddSingleton<UpsertComment_OnModerationResultSet_Mapper>()
                .AddSingleton<UpsertComment_OnContentUpdated_Mapper>()
                .AddSingleton<UpsertComment_OnCommentDeleted_Mapper>()

                .AddSingleton<UpsertUser_OnAccountCreated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountUserNameUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountNameUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountMediaSet_Mapper>()
                .AddMassTransit(
                    x =>
                    {
                        x.AddConsumer<UpsertComment_OnCommentCreated_CommentQueryService>();
                        x.AddConsumer<IncreaseChildCount_OnCommentCreated_CommentQueryService>();
                        x.AddConsumer<UpsertComment_OnModerationResultSet_CommentQueryService>();
                        x.AddConsumer<UpsertComment_OnContentUpdated_CommentQueryService>();
                        x.AddConsumer<UpsertComment_OnCommentDeleted_CommentQueryService>();
                        x.AddConsumer<DecreaseChildCount_OnCommentDeleted_CommentQueryService>();
                        x.AddConsumer<IncreaseLikeCount_OnCommentLiked_CommentQueryService>();
                        x.AddConsumer<DecreaseLikeCount_OnCommentDisliked_CommentQueryService>();

                        x.AddConsumer<UpsertUser_OnAccountCreated_CommentQueryService>();
                        x.AddConsumer<UpsertUser_OnAccountUserNameUpdated_CommentQueryService>();
                        x.AddConsumer<UpsertUser_OnAccountNameUpdated_CommentQueryService>();
                        x.AddConsumer<UpsertUser_OnAccountMediaSet_CommentQueryService>();

                        x.AddConfigureEndpointsCallback((context, name, cfg) =>
                        {
                            cfg.UseMessageRetry(r =>
                            {
                                r.Intervals(10, 50, 100, 1000, 1000, 1000, 1000, 1000);
                            });
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
