using ContentModerator.Infrastructure.AzureAIContentModeration;
using ContentModerator.Infrastructure.FFmpegFrameExtractor;
using ContentModerator.Infrastructure.LocalBlobService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContentModerator.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddAzureAIContentModerationServices(configuration)
                .AddLocalBlobService(configuration)
                .AddFFmpegFrameExtractor();
    }
}
