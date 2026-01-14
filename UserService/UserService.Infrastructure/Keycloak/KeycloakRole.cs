using System.Text.Json.Serialization;

namespace UserService.Infrastructure.Keycloak
{
    internal class KeycloakRole(string id, string name)
    {
        [JsonPropertyName("id")]
        public string Id { get; private set; } = id;
        [JsonPropertyName("name")]
        public string Name { get; private set; } = name;
    }
}
