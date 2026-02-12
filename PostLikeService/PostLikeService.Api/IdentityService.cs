using PostLikeService.Application;
using System.Security.Claims;

namespace PostLikeService.Api
{
    public class IdentityService(IHttpContextAccessor httpContextAccessor) : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public Guid UserId =>
            Guid.Parse(
                _httpContextAccessor
                    .HttpContext?
                    .User
                    .Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?
                    .Value ??
                throw new UnauthorizedException()
            );
    }
}
