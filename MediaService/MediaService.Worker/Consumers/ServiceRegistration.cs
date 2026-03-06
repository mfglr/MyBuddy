using MassTransit;
using MediaService.Infrastructure.MongoDB;
using MediaService.Worker.Consumers;
using MediaService.Worker.Consumers.CreateMedia_OnPostCreated;
using MediaService.Worker.Consumers.CreateMediaOnUserMediaCreated;
using MediaService.Worker.Consumers.DeleteMedia;
using MediaService.Worker.Consumers.SetMetadata_OnMetadataExtractionInvalidated;
using MediaService.Worker.Consumers.SetMetadata_OnMetadataExtractionValidated;
using MediaService.Worker.Consumers.SetModerationResult_OnClassificationInvalidated;
using MediaService.Worker.Consumers.SetModerationResult_OnClassificationValidated;
using MediaService.Worker.Consumers.SetThumbnails;
using MediaService.Worker.Consumers.SetTranscodedBlobName;
using MongoDB.Driver;

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
                .AddSingleton<SetMetadata_OnMetadataExtractionValidated_Mapper>()
                .AddSingleton<SetMetadata_OnMetadataExtractionInvalidated_Mapper>()
                .AddSingleton<SetModerationResult_OnClassificationValidated_Mapper>()
                .AddSingleton<SetModerationResult_OnClassificationInvalidated_Mapper>()
                .AddSingleton<SetThumbnails_OnThumbnailsGenerated_Mapper>()
                .AddSingleton<SetTranscodedBlobName_VideoTrascoded_Mapper>()
                .AddSingleton<DeleteMedia_OnMediaPreprocessingCompleted_Mapper>()
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<CreateMedia_OnPostCreated_MediaService>();
                        brc.AddConsumer<CreateMedia_OnUserMediaCreated_MediaService>();

                        brc.AddConsumer<SetMetadata_OnMetadataExtractionValidated_MediaService>();
                        brc.AddConsumer<SetMetadata_OnMetadataExtractionInvalidated_MediaService>();
                        
                        brc.AddConsumer<SetModerationResult_OnClassificationValidated_MediaService>();
                        brc.AddConsumer<SetModerationResult_OnClassificationInvalidated_MediaService>();
                        
                        brc.AddConsumer<SetThumbnails_OnThumbnailsGenerated_MediaService>();
                        
                        brc.AddConsumer<SetTranscodedBlobName_VideoTrascoded_MediaService>();
                        
                        brc.AddConsumer<DeleteMedia_OnMediaPreprocessingCompleted_MediaService>();

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
                            cfg.UseMessageRetry(r =>
                            {
                                r.Handle<MongoCommandException>();
                                r.Handle<ConflictDetectedException>();
                                r.Immediate(3);
                            });

                            cfg.UseMessageRetry(r =>
                            {
                                r.Ignore<MongoCommandException>();
                                r.Ignore<ConflictDetectedException>();
                                r.Intervals(10, 50, 100, 1000, 1000, 1000, 1000, 1000);
                            });
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
