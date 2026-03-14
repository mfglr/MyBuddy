using Shared.Exceptions;
using System.Net;
using System.Text.Json;
using TokenManager.Abstracts;

namespace TokenManager.Concretes
{
    public class IdentityServerAccessTokenProvider(IdentityServerOpitons options) : IAccessTokenProvider
    {
        public async Task<string> GetAccessTokenAsync(string clientId, string clientSecret, CancellationToken cancellationToken)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(options.HostName)
            };
            var content = new Dictionary<string, string>()
            {
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "grant_type", "client_credentials" }
            };
            var formUrlEncodedContent = new FormUrlEncodedContent(content);

            var response = await client.PostAsync(
                $"connect/token",
                formUrlEncodedContent,
                cancellationToken
            );

            if (response.StatusCode != HttpStatusCode.OK)
                throw new ServerSideException();

            var responseContentString = await response.Content.ReadAsStringAsync(cancellationToken);
            var token = JsonSerializer.Deserialize<Token>(responseContentString)!;
            return token.AccessToken;
        }
    }
}
