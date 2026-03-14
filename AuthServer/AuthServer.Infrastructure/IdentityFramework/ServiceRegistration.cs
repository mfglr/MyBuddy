using AuthServer.Domain;
using AuthServer.Infrastructure.PostgreSql;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.Infrastructure.IdentityFramework
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddIdentityFramework(this IServiceCollection services)
        {
            services
                .AddIdentity<Account, IdentityRole>(opt =>
                {
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<SqlContext>()
                .AddDefaultTokenProviders();
            return services
                .AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
