using ContentModerator.Application.UseCases.ClassifyImage;
using ContentModerator.Application.UseCases.ClassifyText;
using ContentModerator.Application.UseCases.ClassifyVideo;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace ContentModerator.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services
                .AddScoped<TempDirectoryManager>()
                .AddMediator(cfg =>
                {
                    cfg.AddConsumer<ClassifyTextConsumer>();
                    cfg.AddConsumer<ClassifyImageConsumer>();
                    cfg.AddConsumer<ClassifyVideoConsumer>();
                });
    }
}
