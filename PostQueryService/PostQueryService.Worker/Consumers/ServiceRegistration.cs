using MassTransit;
using Microsoft.EntityFrameworkCore;
using PostQueryService.Worker.Consumers;
using PostQueryService.Worker.Consumers.DecreasePostLikeCount;
using PostQueryService.Worker.Consumers.IncreasePostLikeCount;
using PostQueryService.Worker.Consumers.UpdatePostOnPostContentModerationResultSet;
using PostQueryService.Worker.Consumers.UpserPostOnPostCreated;
using PostQueryService.Worker.Consumers.UpsertPostOnPostDeleted;
using PostQueryService.Worker.Consumers.UpsertPostOnPostMediaSet;
using PostQueryService.Worker.Consumers.UpsertPostOnPostRestored;
using PostQueryService.Worker.Consumers.UpsertUserOnNameUpdated;
using PostQueryService.Worker.Consumers.UpsertUserOnUserCreated;
using PostQueryService.Worker.Consumers.UpsertUserOnUserMediaSet;
using PostQueryService.Worker.Consumers.UpsertUserOnUserNameUpdated;

namespace PostQueryService.Worker.Consumers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<UpsertPost_OnPostCreated_Mapper>()
                .AddSingleton<UpdatePost_OnPostContentModerationResultSet_Mapper>()
                .AddSingleton<UpsertPost_OnPostDeleted_Mapper>()
                .AddSingleton<UpsertPost_OnPostRestored_Mapper>()
                .AddSingleton<UpsertPost_OnPostMediaSet_Mapper>()

                .AddSingleton<UpsertUser_OnUserCreated_Mapper>()
                .AddSingleton<UpsertUserOn_UserNameUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnNameUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnUserMediaSet_Mapper>()
                .AddMassTransit(
                    x =>
                    {
                        x.AddConsumer<UpsertPost_OnPostCreated_PostQueryService>();
                        x.AddConsumer<UpdatePost_OnPostContentModerationResultSet_PostQueryService>();
                        x.AddConsumer<UpsertPost_OnPostDeleted_PostQueryService>();
                        x.AddConsumer<UpsertPost_OnPostRestored_PostQueryService>();
                        x.AddConsumer<UpsertPost_OnPostMediaSet_PostQueryService>();
                        x.AddConsumer<IncreasePostLikeCount_OnPostLiked_PostQueryService>();
                        x.AddConsumer<DecreasePostLikeCount_OnPostDisliked_PostQueryService>();

                        x.AddConsumer<UpsertUser_OnUserCreated_PostQueryService>();
                        x.AddConsumer<UpsertUser_OnUserNameUpdated_PostQueryService>();
                        x.AddConsumer<UpsertUser_OnNameUpdated_PostQueryService>();
                        x.AddConsumer<UpsertUser_OnUserMediaSet_PostQueryService>();

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
