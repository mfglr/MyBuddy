using MetadataExtractor.Application;
using Microsoft.Extensions.DependencyInjection;

namespace MetadataExtractor.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) =>
            services
                .AddSingleton<IBlobService, LocalBlobService>()
                .AddSingleton<IMetadataExtractor, FFmpegMetadataExtractor>();
    }
}
