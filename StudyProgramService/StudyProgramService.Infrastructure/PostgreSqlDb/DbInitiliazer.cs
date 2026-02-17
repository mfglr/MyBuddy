using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace StudyProgramService.Infrastructure.PostgreSqlDb
{
    internal static class DbInitiliazer
    {
        public static void Init(IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PostgreSqlContext>();
            context.Database.Migrate();
        }
    }
}
