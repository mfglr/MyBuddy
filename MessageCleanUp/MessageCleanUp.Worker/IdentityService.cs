using MessageService.Application;

namespace MessageCleanUp.Worker
{
    internal class IdentityService : IIdentityService
    {
        public Guid UserId => Guid.NewGuid();
    }
}
