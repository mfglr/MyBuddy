using MessageService.Application;
using System.Security.Claims;

namespace MessageService.Api
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
    }
}
