using Microsoft.Extensions.DependencyInjection;
using VideoTranscoder.Application;

namespace VideoTranscoder.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) =>
            services
                .AddSingleton<IBlobService,LocalBlobService>()
                .AddScoped<IVideoTranscoder, VideoTranscoder>();
    }
}
