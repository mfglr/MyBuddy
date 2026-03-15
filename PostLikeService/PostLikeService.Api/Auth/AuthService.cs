using PostLikeService.Application;
using System.Security.Claims;

namespace PostLikeService.Api.Auth
{
    public class AuthService(IHttpContextAccessor httpContextAccessor) : IAuthService
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
