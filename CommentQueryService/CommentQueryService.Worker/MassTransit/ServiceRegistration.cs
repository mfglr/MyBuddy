using CommentQueryService.Worker.MassTransit;
using CommentQueryService.Worker.MassTransit.Consumers.CreateProjection_OnCommentCreated;
using CommentQueryService.Worker.MassTransit.Consumers.DecreaseChildCount_OnCommentDeleted;
using CommentQueryService.Worker.MassTransit.Consumers.DecreaseLikeCount_OnCommentDisliked;
using CommentQueryService.Worker.MassTransit.Consumers.IncreaseChildCount_OnCommentCreated;
using CommentQueryService.Worker.MassTransit.Consumers.IncreaseLikeCount_OnCommentLiked;
using CommentQueryService.Worker.MassTransit.Consumers.UpdateComment_OnCommentDeleted;
using CommentQueryService.Worker.MassTransit.Consumers.UpdateComment_OnContentUpdated;
using CommentQueryService.Worker.MassTransit.Consumers.UpdateComment_OnModerationResultSet;
using CommentQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountMediaCreated;
using CommentQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountMediaSet;
using CommentQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountNameUpdated;
using CommentQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountUserNameUpdated;
using MassTransit;

namespace CommentQueryService.Worker.MassTransit
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<CreateProjection_OnCommentCreated_Mapper>()
                .AddSingleton<UpdateComment_OnModerationResultSet_Mapper>()
                .AddSingleton<UpdateComment_OnContentUpdated_Mapper>()
                .AddSingleton<UpdateComment_OnCommentDeleted_Mapper>()

                .AddSingleton<UpsertUser_OnAccountUserNameUpdated_Mapper>()
                .AddSingleton<UpdateUser_OnAccountNameUpdated_Mapper>()
                .AddSingleton<UpdateUser_OnAccountMediaCreated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountMediaSet_Mapper>()
                .AddMassTransit(
                    x =>
                    {
                        x.AddConsumer<CreateProjection_OnCommentCreated_CommentQueryService>();
                        x.AddConsumer<IncreaseChildCount_OnCommentCreated_CommentQueryService>();
                        x.AddConsumer<UpdateComment_OnModerationResultSet_CommentQueryService>();
                        x.AddConsumer<UpdateComment_OnContentUpdated_CommentQueryService>();
                        x.AddConsumer<UpdateComment_OnCommentDeleted_CommentQueryService>();
                        x.AddConsumer<DecreaseChildCount_OnCommentDeleted_CommentQueryService>();
                        x.AddConsumer<IncreaseLikeCount_OnCommentLiked_CommentQueryService>();
                        x.AddConsumer<DecreaseLikeCount_OnCommentDisliked_CommentQueryService>();

                        x.AddConsumer<UpdateUser_OnAccountUserNameUpdated_CommentQueryService>();
                        x.AddConsumer<UpdateUser_OnAccountNameUpdated_CommentQueryService>();
                        x.AddConsumer<UpdateUser_OnAccountMediaCreated_CommentQueryService>();
                        x.AddConsumer<UpdateUser_OnAccountMediaSet_CommentQueryService>();

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
