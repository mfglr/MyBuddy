using Microsoft.Extensions.DependencyInjection;

namespace CommentService.Domain
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services) =>
            services
                .AddScoped<CommentCreatorDomainService>();
    }
}
