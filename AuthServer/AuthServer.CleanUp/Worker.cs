using AuthServer.Application.UseCases.DeleteHardAccounts;
using AuthServer.CleanUp.Cleanup;
using MediatR;

namespace AuthServer.CleanUp
{
    public class Worker(IServiceProvider serviceProvider, CleanupOptions options, ILogger<Worker> worker) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                using var scope = serviceProvider.CreateScope();
                var sender = scope.ServiceProvider.GetRequiredService<ISender>();
                var request = new DeleteHardAccountsRequest(TimeSpan.FromDays(options.RetentionPeriod));
                await sender.Send(request, stoppingToken);
                await Task.Delay(TimeSpan.FromHours(options.CleanupInterval), stoppingToken);

                worker.LogInformation(message: $"Cleanup Success: {DateTime.UtcNow}");

            } while (!stoppingToken.IsCancellationRequested);
        }
    }
}
