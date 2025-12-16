using Comment.Api;
using Comment.Api.Options;
using CommentService.Application;
using CommentService.Application.UseCases.CreateComment;
using CommentService.Application.UseCases.DeleteComment;
using CommentService.Application.UseCases.RestoreComment;
using CommentService.Application.UseCases.UpdateCommentContent;
using CommentService.Domain;
using CommentService.Infrastructure;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;

namespace Comment.Api
{
    internal static class ServiceRegistration
    {

        public static IServiceCollection AddDomainServices(this IServiceCollection services) =>
            services
                .AddScoped<CommentCreatorDomainService>();

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services
                .AddMediator(cfg =>
                {
                    cfg.AddConsumer<CreateCommentConsumer>();
                    cfg.AddConsumer<UpdateCommentContentConsumer>();
                    cfg.AddConsumer<DeleteCommentConsumer>();
                    cfg.AddConsumer<RestoreCommentConsumer>();
                });

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<MongoContext>(
                    x => x.UseMongoDB(
                        configuration["MongoDbSettings:ConnectionString"]!,
                        configuration["MongoDbSettings:DatabaseName"]!
                    )
                )
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<ICommentRepository, CommentRepository>();

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddAutoMapper(
                    cfg => {
                        cfg.LicenseKey = configuration["AutoMapper:LicenseKey"]!;
                    },
                    Assembly.GetExecutingAssembly(),
                    Assembly.GetAssembly(typeof(IUnitOfWork))
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
                            ValidateIssuer = true
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
                .AddScoped<IIdentityService, IdentityService>();
        }
    }
}
