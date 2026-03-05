using MassTransit;
using MongoDB.Driver;
using UserQueryService.Shared.MongoDB;
using UserQueryService.Worker.Consumers;
using UserQueryService.Worker.Consumers.UpsertUserOnGenderUpdated;
using UserQueryService.Worker.Consumers.UpsertUserOnNameUpdated;
using UserQueryService.Worker.Consumers.UpsertUserOnUserCreated;
using UserQueryService.Worker.Consumers.UpsertUserOnUserMediaSet;
using UserQueryService.Worker.Consumers.UpsertUserOnUserNameUpdated;

namespace UserQueryService.Worker.Consumers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<UpsertUserOnGenderUpdatedMapper>()
                .AddSingleton<UpsertUserOnNameUpdatedMapper>()
                .AddSingleton<UpsertUserOnUserCreatedMapper>()
                .AddSingleton<UpsertUserOnUserMediaSetMapper>()
                .AddSingleton<UpsertUserOnUserNameUpdatedMapper>()
                .AddMassTransit(
                    x =>
                    {
                        x.AddConsumer<UpsertUserOnGenderUpdatedConsumer>();
                        x.AddConsumer<UpsertUserOnNameUpdatedConsumer>();
                        x.AddConsumer<UpsertUserOnUserCreatedConsumer>();
                        x.AddConsumer<UpsertUserOnUserMediaSetConsumer>();
                        x.AddConsumer<UpsertUserOnUserNameUpdatedConsumer>();

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
