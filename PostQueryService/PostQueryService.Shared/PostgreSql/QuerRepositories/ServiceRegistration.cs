using Microsoft.Extensions.DependencyInjection;
using PostQueryService.Shared.Model;

namespace PostQueryService.Shared.PostgreSql.QuerRepositories
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddQueryRepositories(this IServiceCollection services) =>
            services
                .AddSingleton<PostResponseMapper>()
                .AddScoped<IPostQueryRepository, PostQueryRepository>();
    }
}
