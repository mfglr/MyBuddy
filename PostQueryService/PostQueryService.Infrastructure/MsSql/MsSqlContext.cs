using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PostQueryService.Domain.PostDomain;
using PostQueryService.Domain.UserDomain;
using System.Reflection;

namespace PostQueryService.Infrastructure.MsSql
{
    internal class MsSqlContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Post> Posts { get; private set; }
        public DbSet<User> Users { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

    internal class MsSqlContextFactory : IDesignTimeDbContextFactory<MsSqlContext>
    {
        public MsSqlContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MsSqlContext>();
            builder.UseSqlServer("Server=localhost;Database=PostQueryDB;User Id=sa;Password=123456789Abc*;Encrypt=False;Trust Server Certificate=False;");
            return new MsSqlContext(builder.Options);
        }
    }

}
