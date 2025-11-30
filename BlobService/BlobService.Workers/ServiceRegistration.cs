using MassTransit;

namespace BlobService.Workers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMasstransit(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddMassTransit(
                    x =>
                    {
                        x.AddConsumer<DeleteBlobs>();

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
