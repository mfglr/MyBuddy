using AuthServer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AuthServer.Infrastructure.IdentityServer
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddAppIdentityServer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddIdentityServer()
                .AddIdentityServerContexts(configuration)
                .AddAspNetIdentity<Account>()
                .AddProfileService<CustomProfileService>()
                .AddResourceOwnerValidator<PasswordValidator>()
                .AddDeveloperSigningCredential();
            return services;
        }

        private static IIdentityServerBuilder AddIdentityServerContexts(this IIdentityServerBuilder builder, IConfiguration configuration) =>
            builder
                .AddConfigurationStore(opt =>
                {
                    opt.ConfigureDbContext = builder => builder.UseNpgsql(
                        configuration.GetConnectionString("PostgreSql"),
                        npgsqlOpt => npgsqlOpt.MigrationsAssembly(Assembly.GetAssembly(typeof(ServiceRegistration))!)
                    );
                })
                .AddOperationalStore(opt =>
                {
                    opt.ConfigureDbContext = c => c.UseNpgsql(
                        configuration.GetConnectionString("PostgreSql"),
                        npgsqlOpt => npgsqlOpt.MigrationsAssembly(Assembly.GetAssembly(typeof(ServiceRegistration))!)
                    );
                });

    }
}
