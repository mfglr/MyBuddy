using MassTransit;
using Microsoft.EntityFrameworkCore;
using PostService.Infrastructure.PostgreSql;
using PostService.Workers.Consumers;

namespace PostService.Workers.Consumers
{
    internal class MassTransitOptions
    {
        public required string Host { get; set; }
        public required string VirtualHost { get; set; }
        public required string Password { get; set; }
        public required string UserName { get; set; }
    }

    internal static class ServiceRegistration
    {

        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<SetPostContentModerationResult.Mapper>()
                .AddSingleton<SetPostMedia.Mapper>()
                .AddMassTransit(
                    x =>
                    {
                        x.AddEntityFrameworkOutbox<SqlContext>(o =>
                        {
                            o.UsePostgres();
                            o.UseBusOutbox();
                        });

                        var retryLimit = 5;
                        x.AddConfigureEndpointsCallback((context, name, cfg) =>
                        {
                            cfg.UseMessageRetry(r =>
                            {
                                r.Handle<DbUpdateConcurrencyException>();
                                r.Immediate(retryLimit);
                            });
                            cfg.UseMessageRetry(r =>
                            {
                                r.Ignore<DbUpdateConcurrencyException>();
                                r.Intervals(100, 500, 1000, 1000, 1000, 1000, 1000);
                            });
                            cfg.UseEntityFrameworkOutbox<SqlContext>(context);
                        });

                        x.AddConsumer<SetPostContentModerationResult.SetPostContentModerationResult>();
                        //x.AddConsumer<SetPostMedia.SetPostMedia>();

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
