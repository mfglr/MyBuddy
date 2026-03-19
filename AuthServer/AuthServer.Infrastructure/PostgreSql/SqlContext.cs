using AuthServer.Domain;
using MassTransit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AuthServer.Infrastructure.PostgreSql
{
    public class SqlContext(DbContextOptions<SqlContext> options) : IdentityDbContext<Account>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Account>().Ignore(x => x.ConcurrencyStamp);
            builder.Entity<Account>().Property(x => x.Version).IsConcurrencyToken();
            builder.Entity<Account>().OwnsOne(x => x.Name);

            builder.AddInboxStateEntity();
            builder.AddOutboxMessageEntity();
            builder.AddOutboxStateEntity();
        }
    }

    internal class SqlContextFactory : IDesignTimeDbContextFactory<SqlContext>
    {
        public SqlContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqlContext>();
            builder.UseNpgsql("Host=localhost;Port=2345;Username=postgres;Password=123456789Abc*;Database=AccountDB");
            return new(builder.Options);
        }
    }
}
