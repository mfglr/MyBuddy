using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MediaService.Infrastructure.PostgreSql
{
    public class DbInitializer
    {
        public static void Init(IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetService<SqlContext>()!;
            context.Database.Migrate();
        }
    }
}
