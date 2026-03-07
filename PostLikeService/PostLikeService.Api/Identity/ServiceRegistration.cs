using Microsoft.AspNetCore.Authentication.JwtBearer;
using PostLikeService.Application;
using System.Security.Claims;

namespace PostLikeService.Api.Identity
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(IdentityOptions)).Get<IdentityOptions>()!;
            services
                .AddAuthentication()
                .AddJwtBearer(
                    JwtBearerDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.Authority = option.BaseUrl;
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
                                    p.RequireClaim(ClaimTypes.Email);
                                    p.RequireRole("user");
                                }
                            );
                    }
                );
            return services
                .AddHttpContextAccessor()
                .AddScoped<IIdentityService,IdentityService>();
        }
    }
}
