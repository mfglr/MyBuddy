using ContentModerator.Application;
using Microsoft.Extensions.DependencyInjection;

namespace ContentModerator.Infrastructure.FFmpegFrameExtractor
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddFFmpegFrameExtractor(this IServiceCollection services)
        {
            FFmpegConfigration.Configure();
            return services
                .AddSingleton<IImageFrameExtractor, ImageFrameExtractor>()
                .AddSingleton<IVideoFrameExtractor, VideoFrameExtractor>();
        }
    }
}
