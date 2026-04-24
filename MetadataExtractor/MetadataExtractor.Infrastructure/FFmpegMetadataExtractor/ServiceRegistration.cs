using MetadataExtractor.Application;
using Microsoft.Extensions.DependencyInjection;

namespace MetadataExtractor.Infrastructure.FFmpegMetadataExtractor
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddFFmpegMetadataExtractor(this IServiceCollection services) =>
            services
                .AddSingleton<FFmpegInitializer>()
                .AddScoped<TempDirectoryManager>()
                .AddScoped<IMetadataExtractor, FFmpegMetadataExtractor>();
            
    }
}
