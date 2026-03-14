using PostService.Application;

namespace PostService.Workers
{
    internal class NullIdentityService : IAuthService
    {
        public Guid UserId => Guid.NewGuid();

        public bool IsAdmin => false;

        public bool IsAdminOrOwner(Guid userId) => false;
    }
}
