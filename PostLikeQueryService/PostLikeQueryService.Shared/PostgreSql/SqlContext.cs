using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PostLikeQueryService.Shared.Model;
using System.Reflection;

namespace PostLikeQueryService.Shared.PostgreSql
{
    internal class SqlContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<PostUserLike> PostUserLikes { get; private set; }
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
            builder.UseNpgsql("Host=localhost;Port=2345;Username=postgres;Password=123456789Abc*;Database=PostQueryDB;");
            return new SqlContext(builder.Options);
        }
    }

}
