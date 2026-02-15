using Microsoft.AspNetCore.Authentication.JwtBearer;
using StudyProgramService.Application;
using System.Security.Claims;

namespace StudyProgramService.Api.ServiceRegistrations
{
    internal class IdentityOptions
    {
        public required string Issuer { get; set; }
        public required string BaseUrl { get; set; }
        public required string Audience { get; set; }
    }

    internal static class IdentityRegistrar
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
