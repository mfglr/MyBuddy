using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostLikeService.Application.UseCases.DislikePost;
using PostLikeService.Application.UseCases.LikePost;
using System.Reflection;

namespace PostLikeService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<DislikePostMapper>()
                .AddSingleton<LikePostMapper>()
                .AddMediatR(
                    x =>
                    {
                        x.LicenseKey = configuration["LuckPenny:LicenseKey"];
                        x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                    }
                )
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkPipelineBehavior<,>));
    }
}
