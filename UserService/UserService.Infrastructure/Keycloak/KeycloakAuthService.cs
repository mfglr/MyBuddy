using Shared.Exceptions;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using UserService.Application;

namespace UserService.Infrastructure.Keycloak
{
    internal class KeycloakAuthService(KeycloakAuthOptions options, KeycloakAccessTokenProvider accessTokenProvider) : IAuthService
    {
        private KeycloakAccessTokenProvider _accessTokenProvider = accessTokenProvider;
        private readonly KeycloakAuthOptions _options = options;
        private static readonly string[] _inputValue = ["VERIFY_EMAIL"];


        private async Task<KeycloakRole> GetRoleAsync(string roleName, string accessToken, CancellationToken cancellationToken)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(_options.HostName)
            };
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            var response = await client.GetAsync(
                $"admin/realms/{_options.RealmName}/roles/{roleName}",
                cancellationToken
            );

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new Exception("Role not found exception!");
            if (response.StatusCode == HttpStatusCode.Forbidden)
                throw new Exception("Client do not have permission to view realm roles");

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<KeycloakRole>(content)!;
        }

        public async Task<Guid> RegisterAsync(string username, string email, string password, CancellationToken cancellationToken)
        {
            var accessToken = await _accessTokenProvider.GetAccessTokenAsync(cancellationToken);

            var client = new HttpClient()
            {
                BaseAddress = new Uri(_options.HostName)
            };
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            object content = new
            {
                username,
                email,
                enabled = true,
                credentials = new List<object> {
                    new {
                        type = "password",
                        temporary = false,
                        value = password,
                    }
                }
            };

            var response = await client.PostAsJsonAsync(
                $"admin/realms/{_options.RealmName}/users",
                content,
                cancellationToken
            );

            if (response.StatusCode == HttpStatusCode.Conflict)
                throw new KeycloakConflictException();

            if (response.StatusCode != HttpStatusCode.Created)
                throw new ServerSideException();

            var userId = response.Headers.Location!.ToString().Split("/").Last();

            return Guid.Parse(userId);
        }

        public async Task SendEmailVerficationMailAsync(Guid userId, CancellationToken cancellationToken)
        {
            var accessToken = await _accessTokenProvider.GetAccessTokenAsync(cancellationToken);

            var client = new HttpClient()
            {
                BaseAddress = new Uri(_options.HostName)
            };
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            var content = JsonContent.Create(_inputValue);

            var response = await client.PutAsync(
                $"admin/realms/{_options.RealmName}/users/{userId}/execute-actions-email",
                content,
                cancellationToken
            );

            if (response.StatusCode != HttpStatusCode.NoContent)
                throw new ServerSideException();
        }

        public async Task AddRoleAsync(Guid userId, string roleName, CancellationToken cancellationToken)
        {
            var accessToken = await _accessTokenProvider.GetAccessTokenAsync(cancellationToken);
            var role = await GetRoleAsync(roleName, accessToken, cancellationToken);

            var client = new HttpClient()
            {
                BaseAddress = new Uri(_options.HostName)
            };
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            var content = new List<object>{
                new
                {
                    id = role.Id,
                    name = role.Name
                }
            };

            var jsonContent = JsonContent.Create(content);
            var response = await client.PostAsync(
                $"admin/realms/{_options.RealmName}/users/{userId}/role-mappings/realm",
                jsonContent,
                cancellationToken
            );

            if (response.StatusCode != HttpStatusCode.NoContent)
                throw new ServerSideException();
        }
    }
}
