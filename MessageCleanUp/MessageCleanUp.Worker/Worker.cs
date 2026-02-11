using MediatR;
using MessageService.Application.UseCases.DeleteExpiredMessages;

namespace MessageCleanUp.Worker
{
    public class Worker(ISender sender) : BackgroundService
    {
        private readonly static int _secondsPerDay = 86_400;
        private readonly static int _cleanUpPreriod = _secondsPerDay * 14;
        private readonly static TimeSpan _timeSpan = TimeSpan.FromDays(1);

        private readonly PeriodicTimer _timer = new(_timeSpan);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(await _timer.WaitForNextTickAsync(stoppingToken))
                await sender.Send(new DeleteExpiredMessagesRequest(_cleanUpPreriod), stoppingToken);
        }
    }
}
