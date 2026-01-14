using System.Security.Claims;
using UserService.Application;

namespace UserService.Api
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
                string.Empty
            );

        public bool IsAdmin =>
            _httpContextAccessor
                .HttpContext?
                .User
                .Claims
                .Any(x => x.Type == ClaimTypes.Role && x.Value == "admin") ?? false;

        public bool IsEmailVerified(){
            var value = _httpContextAccessor
                .HttpContext?
                .User
                .Claims
                .FirstOrDefault(x => x.Type == "email_verified")?
                .Value;
            return value != null && bool.Parse(value);
        }

        public bool IsAdminOrOwner(Guid userId) => IsAdmin || UserId == userId;
    }
}
