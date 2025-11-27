using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using ThumbnailGenerator.Application.UseCases.GenerateThumbnail;

namespace ThumbnailGenerator.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services
                .AddScoped<TempDirectoryManager>()
                .AddMediator(cfg =>
                {
                    cfg.AddConsumer<GenerateThumbnailConsumer>();
                });
    }
}
