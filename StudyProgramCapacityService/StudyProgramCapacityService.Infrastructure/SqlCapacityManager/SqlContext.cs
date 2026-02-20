using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StudyProgramCapacityService.Domain;

namespace StudyProgramCapacityService.Infrastructure.SqlCapacityManager
{
    internal class SqlContext(DbContextOptions<SqlContext> options) : DbContext(options)
    {
        public DbSet<SPC> StudyProgramCapacities { get; private set; }
    }

    internal class SqlContextFactory : IDesignTimeDbContextFactory<SqlContext>
    {
        public SqlContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=2345;Database=StudyProgramCapacityDB;Username=postgres;Password=123456789Abc*");
            return new SqlContext(optionsBuilder.Options);
        }
    }

}
