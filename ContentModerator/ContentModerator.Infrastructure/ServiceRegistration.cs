using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ContentModerator.Application;
using ContentModerator.Infrastructure.AzureAIContentModeration;

namespace ContentModerator.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddAzureAIContentModerationServices(configuration)
                .AddSingleton<IFrameExtractor, FrameExtractor>()
                .AddSingleton<IImageFrameExtractor, ImageFrameExtractor>()
                .AddSingleton<IVideoFrameExtractor, VideoFrameExtractor>()
                .AddSingleton<IBlobService, LocalBlobService>();
    }
}
