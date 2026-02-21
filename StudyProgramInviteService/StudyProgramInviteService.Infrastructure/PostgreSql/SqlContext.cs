using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StudyProgramInviteService.Domain;
using System.Reflection;

namespace StudyProgramInviteService.Infrastructure.PostgreSql
{
    internal class SqlContext(DbContextOptions<SqlContext> options) : DbContext(options)
    {
        public DbSet<SPI> StudyProgramInvites { get; private set; }
        public DbSet<SPIState> StudyProgramInviteStates { get; private set; }

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
            var builder = new DbContextOptionsBuilder<SqlContext>();
            builder.UseNpgsql("Host=localhost;Port=2345;Database=StudyProgramInviteDB;Username=postgres;Password=123456789Abc*");
            return new SqlContext(builder.Options);
        }
    }

}
