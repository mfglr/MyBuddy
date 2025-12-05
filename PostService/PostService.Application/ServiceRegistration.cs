using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using PostService.Application.UseCases.CreatePost;
using PostService.Application.UseCases.DeletePostMedia;
using PostService.Application.UseCases.SetPostContentModerationResult;
using PostService.Application.UseCases.SetPostMedia;

namespace PostService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services
                .AddMediator(cfg =>
                {
                    cfg.AddConsumer<CreatePostConsumer>();
                    cfg.AddConsumer<DeletePostMediaConsumer>();
                    cfg.AddConsumer<SetPostMediaConsumer>();
                    cfg.AddConsumer<SetPostContentModerationResultConsumer>();
                });
    }
}
