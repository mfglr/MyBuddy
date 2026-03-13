using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PostQueryService.Api.Identity
{
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
                                "read",
                                p =>
                                {
                                    p.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                                    p.RequireAuthenticatedUser();
                                    p.RequireClaim("Scope", ["post_query.read"]);
                                }
                            );
                    }
                );

            return services;
        }
    }
}
