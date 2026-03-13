using AuthServer.Application;
using AuthServer.Domain;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AuthServer.Infrastructure.PostgreSql
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services,IConfiguration configuration) =>
            services
                .AddDbContext<SqlContext>(x => x.UseNpgsql(configuration.GetConnectionString("PostgreSql")))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IAccountRepository, AccountRepository>();  
    }
}
