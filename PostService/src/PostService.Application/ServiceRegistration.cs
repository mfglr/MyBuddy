using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostService.Application.UseCases.CreatePost;
using PostService.Application.UseCases.DeletePost;
using PostService.Application.UseCases.RestorePost;
using PostService.Application.UseCases.SetPostContentModerationResult;
using PostService.Application.UseCases.SetPostMedia;
using System.Reflection;

namespace PostService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuraiton)
        {
            return services
                .AddSingleton<CreatePostMapper>()
                .AddSingleton<DeletePostMapper>()
                .AddSingleton<RestorePostMapper>()
                .AddSingleton<SetPostContentModerationResultMapper>()
                .AddSingleton<SetPostMediaMapper>()
                .AddMediatR(
                    cfg =>
                    {
                        cfg.LicenseKey = configuraiton.GetSection("LuckPenny:LicenseKey").Value;
                        cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                    }
                )
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkPipelineBehavior<,>));
        }
    }
}
