using MassTransit;
using MediaService.Infrastructure;

namespace MediaService.Workers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMasstransit(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddMassTransit(
                    x =>
                    {
                        x.AddConsumer<CreateMedia>();
                        x.AddConsumer<SetMediaModerationResult>();
                        x.AddConsumer<SetMediaThumbnail>();
                        x.AddConsumer<SetMediaTranscodedBlobName>();
                        x.AddConsumer<SetMediaMetadata>();

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host(configuration["RabbitMQ:Host"], configuration["RabbitMQ:VirtualHost"], h =>
                            {
                                h.Username(configuration["RabbitMQ:UserName"]!);
                                h.Password(configuration["RabbitMQ:Password"]!);
                            });

                            var retryLimit = 4;

                            cfg.ReceiveEndpoint("SetMediaModerationResult", e =>
                            {
                                e.UseMessageRetry(cfg =>
                                {
                                    cfg.Immediate(retryLimit);
                                    cfg.Handle<AppConcurrencyException>();
                                });
                                e.ConfigureConsumer<SetMediaModerationResult>(context);
                            });

                            //720 and 360Squre
                            cfg.ReceiveEndpoint("SetMediaThumbnail", e =>
                            {
                                e.UseMessageRetry(cfg =>
                                {
                                    cfg.Immediate(retryLimit);
                                    cfg.Handle<AppConcurrencyException>();
                                });
                                e.ConfigureConsumer<SetMediaThumbnail>(context);
                            });

                            cfg.ReceiveEndpoint("SetMediaTranscodedBlobName", e =>
                            {
                                e.UseMessageRetry(cfg =>
                                {
                                    cfg.Immediate(retryLimit);
                                    cfg.Handle<AppConcurrencyException>();
                                });
                                e.ConfigureConsumer<SetMediaTranscodedBlobName>(context);
                            });

                            cfg.ReceiveEndpoint("SetMediaMetadata", e =>
                            {
                                e.UseMessageRetry(cfg =>
                                {
                                    cfg.Immediate(retryLimit);
                                    cfg.Handle<AppConcurrencyException>();
                                });
                                e.ConfigureConsumer<SetMediaMetadata>(context);
                            });

                            cfg.ConfigureEndpoints(context);
                        });
                    }
                );
    }
}
