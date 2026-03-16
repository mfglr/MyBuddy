using CommentQueryService.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace CommentQueryService.Shared.PostgreSql
{
    internal class SqlContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Comment> Comments { get; private set; }
        public DbSet<User> Users { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<Media>();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

    internal class SqlContextFactory : IDesignTimeDbContextFactory<SqlContext>
    {
        public SqlContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqlContext>();
            builder.UseNpgsql("Host=localhost;Port=2345;Username=postgres;Password=123456789Abc*;Database=CommentQueryDB;");
            return new SqlContext(builder.Options);
        }
    }

}
