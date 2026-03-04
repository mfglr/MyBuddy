using MassTransit;
using MediaService.Worker.Consumers;
using MongoDB.Driver;

namespace MediaService.Worker.Consumers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<CreateMedia_OnPostCreated.Mapper>()
                .AddSingleton<SetMetadata_OnMetadataExtractionValidated.Mapper>()
                .AddSingleton<SetMetadata_OnMetadataExtractionInvalidated.Mapper>()
                .AddSingleton<SetModerationResult_OnClassificationValidated.Mapper>()
                .AddSingleton<SetModerationResult_OnClassificationInvalidated.Mapper>()
                .AddSingleton<SetThumbnails.Mapper>()
                .AddSingleton<SetTranscodedBlobName.Mapper>()
                .AddSingleton<DeleteMedia.Mapper>()
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<CreateMedia_OnPostCreated.CreateMedia_OnPostCreated>();

                        brc.AddConsumer<SetMetadata_OnMetadataExtractionValidated.SetMetadata_OnMetadataExtractionValidated>();
                        brc.AddConsumer<SetMetadata_OnMetadataExtractionInvalidated.SetMetadata_OnMetadataExtractionInvalidated>();
                        
                        brc.AddConsumer<SetModerationResult_OnClassificationValidated.SetModerationResult_OnClassificationValidated>();
                        brc.AddConsumer<SetModerationResult_OnClassificationInvalidated.SetModerationResult_OnClassificationInvalidated>();
                        
                        brc.AddConsumer<SetThumbnails.SetThumbnails>();
                        
                        brc.AddConsumer<SetTranscodedBlobName.SetTranscodedBlobName>();
                        
                        brc.AddConsumer<DeleteMedia.DeleteMedia>();

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
