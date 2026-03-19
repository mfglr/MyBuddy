using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentQueryService.Shared.PostgreSql
{
    public class DbInitializer
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<SqlContext>();
            context.Database.Migrate();
        }
    }
}
