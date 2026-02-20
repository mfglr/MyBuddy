using Shared.Exceptions;
using StudyProgramApplicationService.Application;
using System.Security.Claims;

namespace StudyProgramApplicationService.Api.Identity
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
