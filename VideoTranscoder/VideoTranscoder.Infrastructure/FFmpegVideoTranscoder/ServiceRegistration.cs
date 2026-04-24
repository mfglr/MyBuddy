using Microsoft.Extensions.DependencyInjection;
using VideoTranscoder.Application;

namespace VideoTranscoder.Infrastructure.FFmpegVideoTranscoder
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddFFmpegVideoTranscoder(this IServiceCollection services) =>
            services
                .AddSingleton<FFmpegInitializer>()
                .AddScoped<IVideoTranscoder, VideoTranscoder>();
    }
}
