using MassTransit;
using MassTransit.Configuration;
using MediaService.Infrastructure.PostgreSql;
using MediaService.Worker.Consumers;
using Microsoft.EntityFrameworkCore;

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
                        var retryLimit = 4;
                        brc.AddConfigureEndpointsCallback((context, name, cfg) =>
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

                        brc.AddEntityFrameworkOutbox<SqlContext>(o =>
                        {
                            o.UsePostgres();
                            o.UseBusOutbox();
                        });
                        

                        brc.AddConsumer<CreateMedia_OnPostCreated.CreateMedia_OnPostCreated>();

                        brc.AddConsumer<SetMetadata_OnMetadataExtractionValidated.SetMetadata_OnMetadataExtractionValidated>();
                        brc.AddConsumer<SetMetadata_OnMetadataExtractionInvalidated.SetMetadata_OnMetadataExtractionInvalidated>();
                        
                        brc.AddConsumer<SetModerationResult_OnClassificationValidated.SetModerationResult_OnClassificationValidated>();
                        brc.AddConsumer<SetModerationResult_OnClassificationInvalidated.SetModerationResult_OnClassificationInvalidated>();
                        
                        brc.AddConsumer<SetThumbnails.SetThumbnails>();
                        
                        brc.AddConsumer<SetTranscodedBlobName.SetTranscodedBlobName>();
                        
                        brc.AddConsumer<DeleteMedia.DeleteMedia>();

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
