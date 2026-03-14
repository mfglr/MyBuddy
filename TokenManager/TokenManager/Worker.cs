using TokenManager.Abstracts;
using TokenManager.Concretes;

namespace TokenManager
{
    public class Worker(
        IHealthChecker healthChecker,
        IAccessTokenCache accessTokenCache,
        IAccessTokenProvider accessTokenProvider,
        IdentityServerOpitons options,
        ILogger<Worker> logger
    ) : BackgroundService
    {
        private readonly static int _expiresIn = 600;
        private readonly static int _safetyWindow = 60;
        private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(_expiresIn - _safetyWindow));

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await WaitUntillServerIsReady();
            do
            {
                var tasks = new List<Task>();
                foreach (var client in options.Clients)
                    tasks.Add(SetAccessToken(client, stoppingToken));
                await Task.WhenAll(tasks);
            } while (await _timer.WaitForNextTickAsync(stoppingToken));
        }

        private async Task SetAccessToken(Client client, CancellationToken cancellationToken)
        {
            var accessToken = await accessTokenProvider.GetAccessTokenAsync(
                client.ClientId,
                client.ClientSecret,
                cancellationToken
            );
            accessTokenCache.Set(client.ClientId, accessToken);
            logger.Log(LogLevel.Information, $"{client.ClientId} has been authenticated.");
        }

        private async Task WaitUntillServerIsReady()
        {
            bool retry = true;
            do
            {
                try
                {
                    await healthChecker.CheckAsync();
                    retry = false;
                }
                catch (Exception)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            } while (retry);
        }
    }
}
