using UserQueryService.CleanUp.Cleanup;
using UserQueryService.Shared.Model;

namespace UserQueryService.CleanUp
{
    public class Worker(IServiceProvider serviceProvider,CleanupOptions cleanupOptions) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                using var scope = serviceProvider.CreateScope();
                var repository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

                var timeSpan = TimeSpan.FromDays(cleanupOptions.RetentionPeriod);
                await repository.DeleteHardAsync(timeSpan, stoppingToken);

                await Task.Delay(TimeSpan.FromHours(cleanupOptions.CleanupInterval),stoppingToken);
            } while (!stoppingToken.IsCancellationRequested);
        }
    }
}
