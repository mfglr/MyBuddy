using MassTransit;
using UserQueryService.Worker.Consumers;
using UserQueryService.Worker.Consumers.UpsertUserOnAccountCreated;
using UserQueryService.Worker.Consumers.UpsertUserOnAccountGenderUpdated;
using UserQueryService.Worker.Consumers.UpsertUserOnAccountMediaSet;
using UserQueryService.Worker.Consumers.UpsertUserOnAccountNameUpdated;
using UserQueryService.Worker.Consumers.UpsertUserOnAccountUserNameUpdated;

namespace UserQueryService.Worker.Consumers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<UpsertUser_OnAccountGenderUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountNameUpdated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountCreated_Mapper>()
                .AddSingleton<UpsertUser_OnAccountMediaSet_Mapper>()
                .AddSingleton<UpsertUser_OnAccountUserNameUpdated_Mapper>()
                .AddMassTransit(
                    x =>
                    {
                        x.AddConsumer<UpsertUser_OnAccountGenderUpdated_UserQueryService>();
                        x.AddConsumer<UpsertUser_OnAccountNameUpdated_UserQueryService>();
                        x.AddConsumer<UpsertUser_OnAccountCreated_UserQueryService>();
                        x.AddConsumer<UpsertUser_OnAccountMediaSet_UserQueryService>();
                        x.AddConsumer<UpsertUser_OnAccountUserNameUpdated_UserQueryService>();

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
