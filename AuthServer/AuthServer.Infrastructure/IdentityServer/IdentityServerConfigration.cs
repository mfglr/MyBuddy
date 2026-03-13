using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace AuthServer.Infrastructure.IdentityServer
{
    public static class IdentityServerConfigration
    {
        public static IEnumerable<ApiResource> GetApiResources() =>
            [
                new("account.api"){
                    Scopes = [
                        "account"
                    ]
                },
            ];

        public static IEnumerable<ApiScope> GetApiScopes() =>
            [
                new("account"),
            ];

        public static IEnumerable<Client> GetClients() =>
            [
                new (){
                    ClientId = "postman.client",
                    ClientSecrets = [new Secret("secret".Sha256())],
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AccessTokenLifetime = 900,
                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    AllowedScopes = [
                        "account",
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                    ]
                },
            ];

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            [
                new IdentityResources.OpenId()
            ];
    }
}
