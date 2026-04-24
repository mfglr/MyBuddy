using CommentLikeService.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CommentLikeService.Api.Auth
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
                        options.Authority = option.Authority;
                        options.Audience = option.Audience;
                        options.RequireHttpsMetadata = false;

                        options.TokenValidationParameters = new()
                        {
                            ValidateAudience = true,
                            ValidateIssuerSigningKey = true,
                            ValidateLifetime = true,
                            ValidIssuer = option.Issuer,
                            ValidateIssuer = true,
                        };
                    }
                );

            services
                .AddAuthorization(
                    options =>
                    {
                        options
                            .AddPolicy(
                                "user",
                                p =>
                                {
                                    p.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                                    p.RequireAuthenticatedUser();
                                    p.RequireRole("user");
                                }
                            );
                    }
                );
            return services
                .AddHttpContextAccessor()
                .AddScoped<IAuthService,AuthService>();
        }
    }
}
