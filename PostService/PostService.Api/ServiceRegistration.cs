using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PostService.Api.Options;
using PostService.Application;
using PostService.Application.UseCases.CreatePost;
using PostService.Application.UseCases.CreatePostMedia;
using PostService.Application.UseCases.DeletePost;
using PostService.Application.UseCases.DeletePostMedia;
using PostService.Application.UseCases.RestorePost;
using PostService.Application.UseCases.UpdatePostContent;
using PostService.Domain;
using PostService.Infrastructure;
using System.Reflection;
using System.Security.Claims;

namespace PostService.Api
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services
                .AddMediator(cfg =>
                {
                    cfg.AddConsumer<CreatePostConsumer>();
                    cfg.AddConsumer<DeletePostMediaConsumer>();
                    cfg.AddConsumer<CreatePostMediaConsumer>();
                    cfg.AddConsumer<UpdatePostContentConsumer>();
                    cfg.AddConsumer<DeletePostConsumer>();
                    cfg.AddConsumer<RestorePostConsumer>();
                });

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddScoped<IBlobService, LocalBlobService>()
                .AddScoped<MongoContext>()
                .AddScoped<IPostRepository, PostRepository>();


        public static IServiceCollection AddAutoMapper(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddAutoMapper(
                    cfg => {
                        cfg.LicenseKey = configuration["AutoMapper:LicenseKey"]!;
                    },
                    Assembly.GetExecutingAssembly(),
                    Assembly.GetAssembly(typeof(IBlobService))
                );

        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration) =>
            services.AddMassTransit(
                x =>
                {
                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host(configuration["RabbitMQ:Host"], configuration["RabbitMQ:VirtualHost"], h =>
                        {
                            h.Username(configuration["RabbitMQ:UserName"]!);
                            h.Password(configuration["RabbitMQ:Password"]!);
                        });
                    });
                }
            );

        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
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
                            NameClaimType = "preferred_username"
                        };
                    }
                );

            services
                .AddAuthorization(
                    options =>
                    {
                        options
                            .AddPolicy(
                                "ClientCredential",
                                p =>
                                {
                                    p.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                                    p.RequireAuthenticatedUser();
                                }
                            );

                        options
                            .AddPolicy(
                                "Password",
                                p =>
                                {
                                    p.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                                    p.RequireAuthenticatedUser();
                                    p.RequireClaim(ClaimTypes.Email);
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
