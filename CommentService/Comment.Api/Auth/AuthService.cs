using CommentService.Application;
using Shared.Events;
using Shared.Exceptions;
using System.Security.Claims;
using Duende.IdentityModel;
using System.Text.Json;

namespace Comment.Api.Auth
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
                throw new AuthorizationException()
            );
    }
}
