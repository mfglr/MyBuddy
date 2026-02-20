using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace StudyProgramCapacityService.Infrastructure.SqlCapacityManager
{
    public static class DbInitiliazer
    {
        public static void Init(IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SqlContext>();
            context.Database.Migrate();
        }
    }
}
