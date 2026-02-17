using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StudyProgramService.Domain;
using System.Reflection;

namespace StudyProgramService.Infrastructure.PostgreSqlDb
{
    public class PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : DbContext(options)
    {
        public DbSet<StudyProgram> StudyPrograms { get; private set; }

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
            optionsBuilder.UseNpgsql("Host=localhost;Port=2345;Database=StudyProgramDB;Username=postgres;Password=123456789Abc*");
            return new PostgreSqlContext(optionsBuilder.Options);
        }
    }
}
