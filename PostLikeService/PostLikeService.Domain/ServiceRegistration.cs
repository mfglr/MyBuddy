using Microsoft.Extensions.DependencyInjection;

namespace PostLikeService.Domain
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services) =>
            services
                .AddScoped<PostLikeDomainService>();
    }
}
