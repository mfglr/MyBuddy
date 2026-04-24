using Microsoft.Extensions.DependencyInjection;

namespace CommentLikeService.Domain
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services) =>
            services
                .AddScoped<CommentLikeDomainService>();
    }
}
