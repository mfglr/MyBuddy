using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StudyProgramApplicationService.Domain;
using System.Reflection;

namespace StudyProgramApplicationService.Infrastructure.PostgreSqlDb
{
    public class PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : DbContext(options)
    {
        public DbSet<StudyProgramApplication> StudyProgramApplications { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

    internal class PostgreSqlContextFactory : IDesignTimeDbContextFactory<PostgreSqlContext>
    {
        public PostgreSqlContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PostgreSqlContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=2345;Database=StudyProgramApplicationDB;Username=postgres;Password=123456789Abc*");
            return new PostgreSqlContext(optionsBuilder.Options);
        }
    }

}
