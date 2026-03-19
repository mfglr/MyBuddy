using AuthServer.Infrastructure.IdentityServer;
using AuthServer.Infrastructure.PostgreSql;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.Infrastructure
{
    public static class DbInitializer
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            var sqlContext = serviceProvider.GetRequiredService<SqlContext>();
            var configurationDbContext = serviceProvider.GetRequiredService<ConfigurationDbContext>();
            var persistedGrantDbContext = serviceProvider.GetRequiredService<PersistedGrantDbContext>();

            sqlContext.Database.Migrate();
            configurationDbContext.Database.Migrate();
            persistedGrantDbContext.Database.Migrate();

            SeedConfiguration(configurationDbContext);
        }

        private static void SeedConfiguration(ConfigurationDbContext context)
        {
            context.ApiResources.RemoveRange(context.ApiResources.ToList());
            context.ApiScopes.RemoveRange(context.ApiScopes.ToList());
            context.Clients.RemoveRange(context.Clients.ToList());
            context.IdentityResources.RemoveRange(context.IdentityResources.ToList());

            context.ApiResources.AddRange(IdentityServerConfigration.GetApiResources().Select(x => x.ToEntity()));
            context.ApiScopes.AddRange(IdentityServerConfigration.GetApiScopes().Select(x => x.ToEntity()));
            context.Clients.AddRange(IdentityServerConfigration.GetClients().Select(x => x.ToEntity()));
            context.IdentityResources.AddRange(IdentityServerConfigration.GetIdentityResources().Select(x => x.ToEntity()));

            context.SaveChanges();
        }
    }
}
