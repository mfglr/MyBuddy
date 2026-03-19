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

                new("post.api"){
                    Scopes = [
                        "post"
                    ]
                },
                new("post_query.api"){
                    Scopes = [
                        "post_query"
                    ]
                },

                new("post_like.api"){
                    Scopes = [
                        "post_like"
                    ]
                },
                new("post_like_query.api"){
                    Scopes = [
                        "post_like_query"
                    ]
                },

                new("user.api"){
                    Scopes = [
                        "user"
                    ]
                },
                new("user_query.api"){
                    Scopes = [
                        "user_query"
                    ]
                },

                new("comment.api"){
                    Scopes = [
                        "comment"
                    ]
                },
                new("comment_query.api"){
                    Scopes = [
                        "comment_query"
                    ]
                },

                new("comment_like.api"){
                    Scopes = [
                        "comment_like"
                    ]
                },

                new("blob.api"){
                    Scopes = [
                        "blob.read",
                        "blob.write",
                        "blob.delete"
                    ]
                }
            ];

        public static IEnumerable<ApiScope> GetApiScopes() =>
            [
                new("account"),
                
                new("post"),
                new("post_query"),

                new("post_like"),
                new("post_like_query"),

                new("user"),
                new("user_query"),    

                new("comment"),
                new("comment_query"),

                new("comment_like"),

                new("blob.read"),
                new("blob.write"),
                new("blob.delete")
            ];

        public static IEnumerable<Client> GetClients() =>
            [
                new (){
                    ClientId = "postman.client",
                    ClientSecrets = [new Secret("secret".Sha256())],
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AccessTokenLifetime = 900, // 15 minutes
                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    AllowedScopes = [
                        "account",

                        "post",
                        "post_query",

                        "post_like",
                        "post_like_query",

                        "user",
                        "user_query",

                        "comment",
                        "comment_query",

                        "comment_like",

                        "blob.read",

                        IdentityServerConstants.StandardScopes.OfflineAccess,
                    ]
                },

                new (){
                    ClientId = "post.client",
                    ClientSecrets = [new Secret("secret".Sha256())],
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AccessTokenLifetime = 600, // 10 minutes
                    AllowedScopes = [
                        "blob.write",
                        "blob.delete"
                    ]
                },

                new (){
                    ClientId = "user.client",
                    ClientSecrets = [new Secret("secret".Sha256())],
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AccessTokenLifetime = 600, // 10 minutes
                    AllowedScopes = [
                        "blob.write",
                        "blob.delete"
                    ]
                },

                new (){
                    ClientId = "metadata_extractor.client",
                    ClientSecrets = [new Secret("secret".Sha256())],
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AccessTokenLifetime =  600, // 10 minutes
                    AllowedScopes = [
                        "blob.read"
                    ]
                },

                new (){
                    ClientId = "content_moderator.client",
                    ClientSecrets = [new Secret("secret".Sha256())],
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AccessTokenLifetime = 600, // 10 minutes
                    AllowedScopes = [
                        "blob.read"
                    ]
                },

                new (){
                    ClientId = "thumbnail_generator.client",
                    ClientSecrets = [new Secret("secret".Sha256())],
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AccessTokenLifetime = 600, // 10 minutes
                    AllowedScopes = [
                        "blob.read",
                        "blob.write",
                        "blob.delete"
                    ]
                },

                new (){
                    ClientId = "video_transcoder.client",
                    ClientSecrets = [new Secret("secret".Sha256())],
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AccessTokenLifetime = 600, // 10 minutes
                    AllowedScopes = [
                        "blob.read",
                        "blob.write",
                        "blob.delete"
                    ]
                }

            ];

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            [
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            ];
    }
}
