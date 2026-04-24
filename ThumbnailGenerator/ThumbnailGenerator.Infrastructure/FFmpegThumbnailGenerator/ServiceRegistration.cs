using Microsoft.Extensions.DependencyInjection;
using ThumbnailGenerator.Application;

namespace ThumbnailGenerator.Infrastructure.FFmpegThumbnailGenerator
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddFFmpegThumbnailGenerator(this IServiceCollection services) =>
            services
                .AddSingleton<FFmpegInitializer>()
                .AddScoped<IThumbnailGenerator, ThumbnailGenerator>();
    }
}
