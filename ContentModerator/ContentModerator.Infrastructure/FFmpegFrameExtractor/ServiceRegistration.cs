using ContentModerator.Application;
using Microsoft.Extensions.DependencyInjection;

namespace ContentModerator.Infrastructure.FFmpegFrameExtractor
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddFFmpegFrameExtractor(this IServiceCollection services) =>
            services
                .AddSingleton<FFmpegInitializer>()
                .AddSingleton<IImageFrameExtractor, ImageFrameExtractor>()
                .AddSingleton<IVideoFrameExtractor, VideoFrameExtractor>();
    }
}
