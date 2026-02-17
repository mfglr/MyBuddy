using EnrollmentRequestService.Application;
using System.Security.Claims;

namespace EnrollmentRequestService.Api.Identity
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
                throw new UnauthorizedException()
            );
    }
}
