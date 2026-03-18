using MassTransit;
using MediaService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace MediaService.Infrastructure.PostgreSql
{
    public class SqlContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Domain.Media> Media { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
        }
    }

    internal class SqlContextFactory : IDesignTimeDbContextFactory<SqlContext>
    {
        public SqlContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqlContext>();
            builder.UseNpgsql("Host=localhost;Port=2345;Username=postgres;Password=123456789Abc*;Database=MediaDB;");
            return new SqlContext(builder.Options);
        }
    }

}
