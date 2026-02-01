using Microsoft.Extensions.DependencyInjection;
using PostQueryService.Application.QueryRepositories;

namespace PostQueryService.Infrastructure.MsSql.QuerRepositories
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddQueryRepositories(this IServiceCollection services) =>
            services
                .AddSingleton<PostResponseMapper>()
                .AddScoped<IPostQueryRepository, PostQueryRepository>();
    }
}
