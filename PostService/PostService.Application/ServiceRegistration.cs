using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using PostService.Application.UseCases.CreatePost;
using PostService.Application.UseCases.SetContentModerationResult;

namespace PostService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services
                .AddMediator(cfg =>
                {
                    cfg.AddConsumer<CreatePostConsumer>();
                    cfg.AddConsumer<SetContentModerationResultConsumer>();
                });
    }
}
