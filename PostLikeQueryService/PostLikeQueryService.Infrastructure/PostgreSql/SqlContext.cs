using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PostLikeQueryService.Domain.PostLikeAggregate;
using PostLikeQueryService.Domain.UserAggregate;
using System.Reflection;

namespace PostLikeQueryService.Infrastructure.PostgreSql
{
    internal class SqlContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; private set; }
        public DbSet<PostLike> PostLikes { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

    internal class SqlContextFactory : IDesignTimeDbContextFactory<SqlContext>
    {
        public SqlContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
            optionsBuilder
                .UseNpgsql("User ID=postgres; Password=123456; Server=localhost; Port=5432; Database=PostLikeQueryDB; Integrated Security=true; Pooling=true");
            return new SqlContext(optionsBuilder.Options);
        }
    }
}
