using MassTransit;
using PostQueryService.Worker.Consumers;
using PostQueryService.Worker.Consumers.UpsertPost_OnPostContentModerationResultSetEvent;
using PostQueryService.Worker.Consumers.UpsertPost_OnPostContentUpdated;
using PostQueryService.Worker.Consumers.UpsertPost_OnPostCreated;
using PostQueryService.Worker.Consumers.UpsertPost_OnPostDeleted;
using PostQueryService.Worker.Consumers.UpsertPost_OnPostMediaSet;
using PostQueryService.Worker.Consumers.UpsertUser_OnAccountCreated;
using PostQueryService.Worker.Consumers.UpsertUser_OnAccountDeleted;
using PostQueryService.Worker.Consumers.UpsertUser_OnAccountMediaCreated;
using PostQueryService.Worker.Consumers.UpsertUser_OnAccountMediaSet;
using PostQueryService.Worker.Consumers.UpsertUser_OnAccountNameUpdated;
using PostQueryService.Worker.Consumers.UpsertUser_OnAccountUserNameUpdated;

namespace PostQueryService.Worker.Consumers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<UpsertUser_OnAccountCreated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountUserNameUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountNameUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountDeleted_Mapper>()
                .AddSingleton<UpsertUser_OnAccountMediaCreated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountMediaSet_Mapper>()

                .AddSingleton<UpsertPost_OnPostContentModerationResultSetEvent_Mapper>()
                .AddSingleton<UpsertPost_OnPostContentUpdated_Mapper>()
                .AddSingleton<UpsertPost_OnPostCreated_Mapper>()
                .AddSingleton<UpsertPost_OnPostMediaSet_Mapper>()
                .AddSingleton<UpsertPost_OnPostDeleted_Mapper>()

                .AddMassTransit(
                    x =>
                    {
                        x.AddConsumer<UpsertUser_OnAccountCreated_PostQueryService>();
                        x.AddConsumer<UpsertUser_OnAccountUserNameUpdated_PostQueryService>();
                        x.AddConsumer<UpsertUser_OnAccountNameUpdated_PostQueryService>();
                        x.AddConsumer<UpsertUser_OnAccountDeleted_PostQueryService>();
                        x.AddConsumer<UpsertUser_OnAccountMediaCreated_PostQueryService>();
                        x.AddConsumer<UpsertUser_OnAccountMediaSet_PostQueryService>();

                        x.AddConsumer<UpsertPost_OnPostContentModerationResultSetEvent_PostQueryService>();
                        x.AddConsumer<UpsertPost_OnPostContentUpdated_PostQueryService>();
                        x.AddConsumer<UpsertPost_OnPostCreated_PostQueryService>();
                        x.AddConsumer<UpsertPost_OnPostMediaSet_PostQueryService>();
                        x.AddConsumer<UpsertPost_OnPostDeleted_PostQueryService>();

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
