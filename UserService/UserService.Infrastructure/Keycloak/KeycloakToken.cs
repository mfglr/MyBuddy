using System.Text.Json.Serialization;

namespace UserService.Infrastructure.Keycloak
{
    internal class KeycloakToken(string accessToken)
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; private set; } = accessToken;
    }
}
