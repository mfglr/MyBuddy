namespace UserService.Infrastructure.Keycloak
{
    public class KeycloakConflictException() : Exception("Email is taken before!");
}
