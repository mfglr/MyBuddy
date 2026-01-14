namespace UserService.Application
{
    public interface IAuthService
    {
        Task<Guid> RegisterAsync(string userName, string email, string password, CancellationToken cancellationToken);
        Task SendEmailVerficationMailAsync(Guid userId, CancellationToken cancellationToken);
        Task AddRoleAsync(Guid userId, string roleName, CancellationToken cancellationToken);
    }
}
