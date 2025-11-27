using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using VideoTranscoder.Application.UseCases.TranscodeVideo;

namespace VideoTranscoder.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services
                .AddScoped<TempDirectoryManager>()
                .AddMediator(cfg =>
                {
                    cfg.AddConsumer<TranscodeVideoConsumer>();
                });
    }
}
