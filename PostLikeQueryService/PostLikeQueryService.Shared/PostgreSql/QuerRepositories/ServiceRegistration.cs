using Microsoft.Extensions.DependencyInjection;
using PostLikeQueryService.Shared.Model;

namespace PostLikeQueryService.Shared.PostgreSql.QuerRepositories
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddQueryRepositories(this IServiceCollection services) =>
            services
                .AddScoped<IPostUserLikeQueryRepository, PostUserLikeQueryRepository>();
    }
}
