using Shared.Exceptions;
using System.Net;
using System.Text.Json;

namespace UserService.Infrastructure.Keycloak
{
    internal class KeycloakAccessTokenProvider(KeycloakAuthOptions options)
    {
        private readonly KeycloakAuthOptions _options = options;
        private string? _scopeAccessToken;

        private async Task<string> GetInternalAccessTokenAsync(CancellationToken cancellationToken)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(_options.HostName)
            };
            var content = new Dictionary<string, string>()
            {
                { "client_id", _options.ClientId },
                { "client_secret", _options.ClientSecret },
                { "grant_type", "client_credentials" }
            };
            var formUrlEncodedContent = new FormUrlEncodedContent(content);

            var response = await client.PostAsync(
                $"realms/{_options.RealmName}/protocol/openid-connect/token",
                formUrlEncodedContent,
                cancellationToken
            );

            if (response.StatusCode != HttpStatusCode.OK)
                throw new ServerSideException();

            var responseContentString = await response.Content.ReadAsStringAsync(cancellationToken);
            var token = JsonSerializer.Deserialize<KeycloakToken>(responseContentString)!;
            return token.AccessToken;
        }

        public async Task<string> GetAccessTokenAsync(CancellationToken cancellationToken) => 
            _scopeAccessToken ??= await GetInternalAccessTokenAsync(cancellationToken);
    }
}
