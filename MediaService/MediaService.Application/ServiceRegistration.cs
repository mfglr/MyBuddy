using MassTransit;
using MediaService.Application.UseCases.CreateMedia;
using MediaService.Application.UseCases.SetMediaMetadata;
using MediaService.Application.UseCases.SetMediaModerationResult;
using MediaService.Application.UseCases.SetMediaThumbnail;
using MediaService.Application.UseCases.SetMediaTranscodedBlobName;
using Microsoft.Extensions.DependencyInjection;

namespace MediaService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services.AddMediator(cfg =>
            {
                cfg.AddConsumer<CreateMediaConsumer>();
                cfg.AddConsumer<SetMediaModerationResultConsumer>();
                cfg.AddConsumer<SetMediaThumbnailConsumer>();
                cfg.AddConsumer<SetMediaTranscodedBlobNameConsumer>();
                cfg.AddConsumer<SetMediaMetadataConsumer>();
            });
    }
}
