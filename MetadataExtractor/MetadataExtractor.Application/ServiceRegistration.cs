using MassTransit;
using MetadataExtractor.Application.UseCases.ExtractMediaMetadata;
using Microsoft.Extensions.DependencyInjection;

namespace MetadataExtractor.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services
                .AddScoped<TempDirectoryManager>()
                .AddMediator(cfg =>
                {
                    cfg.AddConsumer<ExtractMediaMetadataConsumer>();
                });
    }
}
