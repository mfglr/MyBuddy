using CommentLikeQueryService.Worker.MassTransit;
using CommentLikeQueryService.Worker.MassTransit.Consumers.CreateProjection_OnCommentLikeCreated;
using CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateComment_OnCommentDisliked;
using CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateComment_OnCommentLiked;
using CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountMediaCreated;
using CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountMediaSet;
using CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountNameUpdated;
using CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateUser_OnAccountUserNameUpdated;
using MassTransit;

namespace CommentLikeQueryService.Worker.MassTransit
{
    internal static class ServiceRegistrationExtens
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<CreateProjection_OnCommentCreated_Mapper>()
                .AddSingleton<UpdateComment_OnCommentDisliked_Mapper>()
                .AddSingleton<UpdateComment_OnCommentLiked_Mapper>()
                
                .AddSingleton<UpdateUser_OnAccountNameUpdated_Mapper>()
                .AddSingleton<UpdateUser_OnAccountUserNameUpdated_Mapper>()
                .AddSingleton<UpdateUser_OnAccountMediaCreated_Mapper>()
                .AddSingleton<UpdateUser_OnAccountMediaSet_Mapper>()
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<CreateProjection_OnCommentCreated_CommentLikeQueryService>();
                        brc.AddConsumer<UpdateComment_OnCommentDisliked_CommentLikeQueryService>();
                        brc.AddConsumer<UpdateComment_OnCommentLiked_CommentLikeQueryService>();

                        brc.AddConsumer<UpdateUser_OnAccountNameUpdated_CommentLikeQueryService>();
                        brc.AddConsumer<UpdateUser_OnAccountUserNameUpdated_CommentLikeQueryService>();
                        brc.AddConsumer<UpdateUser_OnAccountMediaCreated_CommentLikeQueryService>();
                        brc.AddConsumer<UpdateUser_OnAccountMediaSet_CommentLikeQueryService>();

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
