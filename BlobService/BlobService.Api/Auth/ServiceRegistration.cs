using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BlobService.Api.Auth
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddAuthenticationAndAuthorization(this IServiceCollection services, IConfiguration configuration)
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
                                   p.RequireClaim("scope", ["blob.read"]);
                               }
                           );

                        options
                           .AddPolicy(
                               "write",
                               p =>
                               {
                                   p.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                                   p.RequireAuthenticatedUser();
                                   p.RequireClaim("scope", ["blob.write"]);
                               }
                           );

                        options
                           .AddPolicy(
                               "delete",
                               p =>
                               {
                                   p.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                                   p.RequireAuthenticatedUser();
                                   p.RequireClaim("scope", ["blob.delete"]);
                               }
                           );
                    }
                );
            return services;
        }
    }
}
