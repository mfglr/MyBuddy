using MassTransit;
using MediaService.Infrastructure.PostgreSql;
using MediaService.Worker.Consumers;
using MediaService.Worker.Consumers.AddThumbnails;
using MediaService.Worker.Consumers.AddTranscoding;
using MediaService.Worker.Consumers.CreateMedia_OnPostCreated;
using MediaService.Worker.Consumers.CreateMediaOnUserMediaCreated;
using MediaService.Worker.Consumers.DeleteMedia;
using MediaService.Worker.Consumers.SetMetadata;
using MediaService.Worker.Consumers.SetModerationResult;

namespace MediaService.Worker.Consumers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<CreateMedia_OnPostCreated_Mapper>()
                .AddSingleton<CreateMedia_OnUserMediaCreated_Mapper>()
                .AddSingleton<SetMetadata_OnMetadataExtracted_Mapper>()
                .AddSingleton<SetModerationResult_OnMediaClassified_Mapper>()
                .AddSingleton<AddThumbnails_OnThumbnailsGenerated_Mapper>()
                .AddSingleton<AddTranscoding_OnVideoTrascoded_Mapper>()
                .AddSingleton<DeleteMedia_OnMediaPreprocessingCompleted_Mapper>()
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<CreateMedia_OnPostCreated_MediaService>();
                        brc.AddConsumer<CreateMedia_OnUserMediaCreated_MediaService>();
                        brc.AddConsumer<SetMetadata_OnMetadataExtracted_MediaService>();
                        brc.AddConsumer<SetModerationResult_OnMediaClassified_MediaService>();
                        brc.AddConsumer<AddThumbnails_OnThumbnailsGenerated_MediaService>();
                        brc.AddConsumer<AddTranscoding_OnVideoTrascoded_MediaService>();
                        brc.AddConsumer<DeleteMedia_OnMediaPreprocessingCompleted_MediaService>();

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
