using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using QueryService.Application.UseCases.PostUseCases.CreatePost;

namespace QueryService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services.AddMediator(cfg =>
            {
                cfg.AddConsumer<CreatePostConsumer>();
            });
    }
}
