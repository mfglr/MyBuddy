namespace UserService.Infrastructure.Keycloak
{
    internal record KeycloakAuthOptions(
        string HostName,
        string RealmName,
        string ClientId,
        string ClientSecret
    );
}
