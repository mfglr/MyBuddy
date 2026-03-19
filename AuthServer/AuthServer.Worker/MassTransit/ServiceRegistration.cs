using AuthServer.Infrastructure.PostgreSql;
using AuthServer.Worker.MassTransit;
using AuthServer.Worker.MassTransit.Consumers;
using MassTransit;

namespace AuthServer.Worker.MassTransit
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<SetMedia_OnMediaPreprocessingCompleted_Mapper>()
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<SetMedia_OnMediaPreprocessingCompleted_AuthServer>();

                        brc.AddEntityFrameworkOutbox<SqlContext>(o =>
                        {
                            o.UsePostgres();
                            o.UseBusOutbox();
                        });

                        brc.AddConfigureEndpointsCallback((context, name, cfg) =>
                        {
                            cfg.UseMessageRetry(r =>
                            {
                                r.Intervals(10, 50, 100, 1000, 1000, 1000, 1000, 1000);
                            });
                        });

                        brc.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host(
                                option.Host,
                                option.VirtualHost,
                                rhc =>
                                {
                                    rhc.Username(option.UserName);
                                    rhc.Password(option.Password);
                                }
                            );
                            cfg.ConfigureEndpoints(context);
                        });
                    }
                );
        }
            
    }
}
