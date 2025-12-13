using Microsoft.Extensions.DependencyInjection;

namespace CommentService.Infrastructure
{
    public static class DbConfigurator
    {
        public static void Configure(IServiceCollection services)
        {

            using var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MongoContext>();
            context.Database.EnsureCreated();
        }
    }
}
