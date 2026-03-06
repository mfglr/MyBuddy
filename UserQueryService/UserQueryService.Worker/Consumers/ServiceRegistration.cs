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
                .AddSingleton<UpsertUser_OnGenderUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnNameUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnUserCreated_Mapper>()
                .AddSingleton<UpsertUser_OnUserMediaSet_Mapper>()
                .AddSingleton<UpsertUser_OnUserNameUpdated_Mapper>()
                .AddMassTransit(
                    x =>
                    {
                        x.AddConsumer<UpsertUser_OnGenderUpdated_UserQueryService>();
                        x.AddConsumer<UpsertUser_OnNameUpdated_UserQueryService>();
                        x.AddConsumer<UpsertUser_OnUserCreated_UserQueryService>();
                        x.AddConsumer<UpsertUser_OnUserMediaSet_UserQueryService>();
                        x.AddConsumer<UpsertUser_OnUserNameUpdated_UserQueryService>();

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
