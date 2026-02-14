using MassTransit;
using Microsoft.EntityFrameworkCore;
using PostQueryService.Worker.Consumers.PostDomain;
using PostQueryService.Worker.Consumers.UserDomain;
using PostQueryService.Worker.ServiceRegistrations;

namespace PostQueryService.Worker.ServiceRegistrations
{
    internal class MassTransitOptions
    {
        public required string Host { get; set; }
        public required string VirtualHost { get; set; }
        public required string Password { get; set; }
        public required string UserName { get; set; }
    }

    internal static class MassTransitRegistrar
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services.AddMassTransit(
                x =>
                {
                    x.AddConsumer<UpsertUser_OnUserCreated_PostQueryService>();
                    x.AddConsumer<UpsertUser_OnNameUpdated_PostQueryService>();
                    x.AddConsumer<UpsertUser_OnUserMediaPreprocessingCompleted_PostQueryService>();

                    x.AddConsumer<UpsertPost_OnPostContentModerationResultSet_PostQueryService>();
                    x.AddConsumer<UpsertPost_OnPostProprecessingCompleted_PostQueryService>();
                    x.AddConsumer<UpsertPost_OnPostDeleted_PostQueryService>();
                    x.AddConsumer<UpsertPost_OnPostRestored_PostQueryService>();
                    x.AddConsumer<UpsertUser_OnUserNameUpdated_PostQueryService>();

                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host(option.Host, option.VirtualHost, h =>
                        {
                            h.Username(option.UserName);
                            h.Password(option.Password);
                        });

                        var retryLimit = 1;
                        cfg.ReceiveEndpoint(nameof(UpsertPost_OnPostContentModerationResultSet_PostQueryService), e =>
                        {
                            e.UseMessageRetry(rc =>
                            {
                                rc.Immediate(retryLimit);
                                rc.Handle<DbUpdateConcurrencyException>();
                            });
                            e.ConfigureConsumer<UpsertPost_OnPostContentModerationResultSet_PostQueryService>(context);
                        });

                        cfg.ReceiveEndpoint(nameof(UpsertPost_OnPostProprecessingCompleted_PostQueryService), e =>
                        {
                            e.UseMessageRetry(rc =>
                            {
                                rc.Immediate(retryLimit);
                                rc.Handle<DbUpdateConcurrencyException>();
                            });
                            e.ConfigureConsumer<UpsertPost_OnPostProprecessingCompleted_PostQueryService>(context);
                        });

                        cfg.ConfigureEndpoints(context);
                    });
                }
            );
        }
    }
}
