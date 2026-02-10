using DnsClient.Internal;
using MediatR;
using MessageService.Aplication.UseCases.DeleteMessages;

namespace MessageRemover.Worker
{
    public class Worker(IServiceProvider serviceProvider) : BackgroundService
    {

        private readonly static int _period = 120;
        private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(_period));

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                using var scope = serviceProvider.CreateAsyncScope();
                var sender = scope.ServiceProvider.GetRequiredService<ISender>();
                await sender.Send(new DeleteMessagesRequest())

            } while (await _timer.WaitForNextTickAsync(stoppingToken));
        }
    }
}
