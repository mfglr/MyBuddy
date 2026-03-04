using MassTransit;
using ThumbnailGenerator.Workers.Consumers;
using ThumbnailGenerator.Workers.Consumers.MediaDomain;

namespace ThumbnailGenerator.Workers.Consumers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<Consumers.MediaDomain.Mapper>()
                .AddMassTransit(
                    x =>
                    {
                        x.AddConsumer<GenerateThumbnails>();

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host(configuration["RabbitMQ:Host"], configuration["RabbitMQ:VirtualHost"], h =>
                            {
                                h.Username(configuration["RabbitMQ:UserName"]!);
                                h.Password(configuration["RabbitMQ:Password"]!);
                            });
                            cfg.ConfigureEndpoints(context);
                        });
                    }
                );
    }
}
