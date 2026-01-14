namespace UserService.Application
{
    public interface IIdentityService
    {
        Guid UserId { get; }
        bool IsAdmin { get; }
        bool IsEmailVerified();
        bool IsAdminOrOwner(Guid userId);
    }
}
