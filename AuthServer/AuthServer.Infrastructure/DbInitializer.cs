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
            foreach(var next in IdentityServerConfigration.GetApiResources())
            {
                var prev = context.ApiResources.FirstOrDefaultAsync(x => x.Name == next.Name);
                if (prev == null)
                    context.ApiResources.Add(next.ToEntity());
                else
                    context.ApiResources.Update(next.ToEntity());
            }

            foreach (var next in IdentityServerConfigration.GetApiScopes())
            {
                var prev = context.ApiScopes.FirstOrDefaultAsync(x => x.Name == next.Name);
                if (prev == null)
                    context.ApiScopes.Add(next.ToEntity());
                else
                    context.ApiScopes.Update(next.ToEntity());
            }

            foreach (var next in IdentityServerConfigration.GetClients())
            {
                var prev = context.Clients.FirstOrDefaultAsync(x => x.ClientName == next.ClientName);
                if (prev == null)
                    context.Clients.Add(next.ToEntity());
                else
                    context.Clients.Update(next.ToEntity());
            }

            foreach (var next in IdentityServerConfigration.GetIdentityResources())
            {
                var prev = context.IdentityResources.FirstOrDefaultAsync(x => x.Name == next.Name);
                if (prev == null)
                    context.IdentityResources.Add(next.ToEntity());
                else
                    context.IdentityResources.Update(next.ToEntity());
            }

            context.SaveChanges();
        }
    }
}
