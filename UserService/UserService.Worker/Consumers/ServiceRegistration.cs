using MassTransit;
using MongoDB.Driver;
using UserService.Worker.Consumers;
using UserService.Worker.Consumers.SetUserMedia;
using UserService.Worker.Consumers.ValidateSPICreation;

namespace UserService.Worker.Consumers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<SetUserMediaMapper>()
                .AddSingleton<ValidateSPICreationMapper>()
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<SetUserMediaConsumer>();
                        brc.AddConsumer<ValidateSPICreationConsumer>();

                        brc.AddMongoDbOutbox(o =>
                        {
                            o.QueryDelay = TimeSpan.FromSeconds(1);
                            o.ClientFactory(provider => provider.GetRequiredService<IMongoClient>());
                            o.DatabaseFactory(provider => provider.GetRequiredService<IMongoDatabase>());
                            o.DuplicateDetectionWindow = TimeSpan.FromSeconds(30);
                            o.UseBusOutbox();
                        });

                        brc.AddConfigureEndpointsCallback((context, name, cfg) =>
                        {
                            cfg.UseMessageRetry(r => r.Intervals(10, 50, 100, 1000, 1000, 1000, 1000, 1000));
                            cfg.UseMongoDbOutbox(context);
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
