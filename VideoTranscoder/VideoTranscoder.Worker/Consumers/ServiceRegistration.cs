using MassTransit;
using VideoTranscoder.Worker.Consumers;

namespace VideoTranscoder.Worker.Consumers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<TranscodeVideo.Mapper>()
                .AddMassTransit(
                    x =>
                    {
                        x.AddConsumer<TranscodeVideo.TranscodeVideo>();

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
