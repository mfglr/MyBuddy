namespace TokenManager.Concretes
{
    public record Client(
        string ClientId,
        string ClientSecret
    );

    public record IdentityServerOpitons(
        string HostName,
        IEnumerable<Client> Clients
    );
}
