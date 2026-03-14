using UserService.Application;

namespace UserService.Worker
{
    internal class WorkerIdentityService : IAuthService
    {
        public Guid UserId => Guid.NewGuid();
        public bool IsAdmin => false;
        public bool IsAdminOrOwner(Guid userId) => false;
        public bool IsEmailVerified() => false;
    }
}
