using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostService.Application.UseCases.CreatePost;
using PostService.Application.UseCases.HardDeletePost;
using PostService.Application.UseCases.RestorePost;
using PostService.Application.UseCases.SetPostContentModerationResult;
using PostService.Application.UseCases.SetPostMedia;
using PostService.Application.UseCases.SoftDeleteUserPosts;
using PostService.Application.UseCases.UpdatePostContent;
using System.Reflection;

namespace PostService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuraiton)
        {
            return services
                .AddSingleton<MediaGenerator>()
                .AddSingleton<MediaInstructionCreator>()
                .AddSingleton<MediaTypeExtractor>()
                .AddSingleton<CreatePostMapper>()

                .AddSingleton<RestorePostMapper>()
                .AddSingleton<SetPostContentModerationResultMapper>()
                .AddSingleton<SetPostMediaMapper>()
                .AddSingleton<SoftDeleteUserPostsMapper>()
                .AddSingleton<UpdatePostContentMapper>()
                .AddSingleton<HardDeletePostMapper>()
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
