using TokenManager.Abstracts;

namespace TokenManager.Concretes
{
    public class IdentityServerHealthChecker(IdentityServerOpitons options) : IHealthChecker
    {
        public async Task CheckAsync()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(options.HostName)
            };
            var message = await client.GetAsync("/health");

            if (!message.IsSuccessStatusCode)
                throw new Exception();
        }
    }
}
