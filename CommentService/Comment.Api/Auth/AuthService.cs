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

        private Guid UserId =>
            Guid.Parse(
                _httpContextAccessor
                    .HttpContext?
                    .User
                    .Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?
                    .Value ??
                throw new AuthorizationException()
            );

        private int Version =>
            int.Parse(
                _httpContextAccessor
                    .HttpContext?
                    .User
                    .Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.Version)?
                    .Value ??
                throw new AuthorizationException()
            );

        private string UserName =>
            _httpContextAccessor
                .HttpContext?
                .User
                .Claims
                .FirstOrDefault(x => x.Type == JwtClaimTypes.PreferredUserName)?
                .Value ??
            throw new AuthorizationException();

        private string? Name =>
            _httpContextAccessor
                .HttpContext?
                .User
                .Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.Name)?
                .Value;

        private CurrentUserMedia? Media
        {
            get
            {
                var picture = _httpContextAccessor
                    .HttpContext?
                    .User
                    .Claims
                    .FirstOrDefault(x => x.Type == JwtClaimTypes.Picture)?
                    .Value;

                return picture != null ? JsonSerializer.Deserialize<CurrentUserMedia>(picture) : null;
            }
        }


        public CurrentUser CurrentUser => new (UserId, Version, UserName, Name, Media);
    }
}
