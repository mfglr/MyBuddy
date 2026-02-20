using Shared.Exceptions;
using StudyProgramCapacityService.Application;
using System.Security.Claims;

namespace StudyProgramCapacityService.Api.Identity
{
    public class IdentityService(IHttpContextAccessor httpContextAccessor) : IIdentityService
    {
        public Guid UserId => Guid.Parse(
                httpContextAccessor
                    .HttpContext?
                    .User
                    .Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?
                    .Value ??
                throw new AuthorizationException()
            );
    }
}
