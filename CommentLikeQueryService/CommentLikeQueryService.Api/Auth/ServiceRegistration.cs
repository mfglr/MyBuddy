using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CommentLikeQueryService.Api.Auth
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddAuthenticationAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(AuthOptions)).Get<AuthOptions>()!;
            services
                .AddAuthentication()
                .AddJwtBearer(
                    JwtBearerDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.Authority = option.Issuer;
                        options.Audience = option.Audience;
                        options.RequireHttpsMetadata = false;

                        options.TokenValidationParameters = new()
                        {
                            ValidateAudience = true,
                            ValidateIssuerSigningKey = true,
                            ValidateLifetime = true,
                            ValidateIssuer = true,
                        };
                    }
                );

            return services
                .AddAuthorization(
                    options =>
                    {
                        options
                            .AddPolicy(
                                "comment-like-query",
                                p =>
                                {
                                    p.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                                    p.RequireAuthenticatedUser();
                                    p.RequireClaim("scope",["comment-like-query"]);
                                }
                            );
                    }
                );
        }
    }
}
