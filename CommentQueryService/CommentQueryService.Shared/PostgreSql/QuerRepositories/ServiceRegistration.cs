using CommentQueryService.Shared.Model;
using Microsoft.Extensions.DependencyInjection;

namespace CommentQueryService.Shared.PostgreSql.QuerRepositories
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddQueryRepositories(this IServiceCollection services) =>
            services
                .AddScoped<ICommentQueryRepository, CommentQueryRepository>();
    }
}
