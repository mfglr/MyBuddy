using CommentLikeQueryService.Application.UseCases.CreateCommentLike;
using CommentLikeQueryService.Application.UseCases.UpsertUser;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CommentLikeQueryService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<CommentLikeResponseMapper>()
                .AddSingleton<CreateCommentLikeMapper>()
                .AddSingleton<UpsertUserMapper>()
                .AddMediatR(
                    x =>
                    {
                        x.LicenseKey = configuration["LuckPenny:LicenseKey"];
                        x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                    }
                );
    }
}
