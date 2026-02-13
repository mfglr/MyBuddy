using PostLikeService.Application;

namespace PostLikeService.Worker
{
    public class IdentityService : IIdentityService
    {
        public Guid UserId => Guid.NewGuid();
    }
}
