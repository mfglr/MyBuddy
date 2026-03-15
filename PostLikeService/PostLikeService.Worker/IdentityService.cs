using PostLikeService.Application;

namespace PostLikeService.Worker
{
    public class IdentityService : IAuthService
    {
        public Guid UserId => Guid.NewGuid();
    }
}
