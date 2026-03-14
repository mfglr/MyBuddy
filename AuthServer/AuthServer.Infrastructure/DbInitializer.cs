using AuthServer.Infrastructure.IdentityServer;
using AuthServer.Infrastructure.PostgreSql;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.Infrastructure
{
    public class DbInitializer
    {
        public static void Init(IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var sqlContext = scope.ServiceProvider.GetRequiredService<SqlContext>();
            var configurationDbContext = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            var persistedGrantDbContext = scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>();

            sqlContext.Database.Migrate();
            configurationDbContext.Database.Migrate();
            persistedGrantDbContext.Database.Migrate();

            SeedRoles(roleManager);
            SeedConfiguration(configurationDbContext);
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in IdentityServerConfigration.GetIdentityRoles())
            {
                var task = roleManager.FindByNameAsync(role.Name!);
                task.Wait();
                if (task.Result == null)
                    roleManager.CreateAsync(role).Wait();
            }
        }

        private static void SeedConfiguration(ConfigurationDbContext context)
        {
            if (!context.ApiResources.Any())
                context.ApiResources.AddRange(IdentityServerConfigration.GetApiResources().Select(x => x.ToEntity()));

            if (!context.ApiScopes.Any())
                context.ApiScopes.AddRange(IdentityServerConfigration.GetApiScopes().Select(x => x.ToEntity()));

            if (!context.Clients.Any())
                context.Clients.AddRange(IdentityServerConfigration.GetClients().Select(x => x.ToEntity()));

            if (!context.IdentityResources.Any())
                context.IdentityResources.AddRange(IdentityServerConfigration.GetIdentityResources().Select(x => x.ToEntity()));

            context.SaveChanges();
        }
    }
}
