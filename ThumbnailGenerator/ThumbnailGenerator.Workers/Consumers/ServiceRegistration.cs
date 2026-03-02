using MassTransit;
using ThumbnailGenerator.Workers.Consumers;
using ThumbnailGenerator.Workers.Consumers.MediaDomain;
using ThumbnailGenerator.Workers.Consumers.UserDomain;

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

                        //user domain
                        x.AddConsumer<Generate64SquareThumbnail_OnUserMediaCreated_ThumbnailGenerator>();
                        x.AddConsumer<Generate128SquareThumbnail_OnUserMediaCreated_ThumbnailGenerator>();
                        x.AddConsumer<Generate256SquareThumbnail_OnUserMediaCreated_ThumbnailGenerator>();
                        x.AddConsumer<Generate720Thumbnail_OnUserMediaCreated_ThumbnailGenerator>();
                        //user domain

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
