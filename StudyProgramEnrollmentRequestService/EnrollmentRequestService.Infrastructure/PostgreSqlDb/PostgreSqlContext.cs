using EnrollmentRequestService.Domain;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace EnrollmentRequestService.Infrastructure.PostgreSqlDb
{
    public class PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : DbContext(options)
    {
        public DbSet<EnrollmentRequest> EnrollmentRequests { get; private set; }

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
            optionsBuilder.UseNpgsql("Server=localhost;Port=2345;User ID=postgres;Password=123456789Abc*;Database=StudyProgramEnrollmentRequestDB;Pooling=true");
            return new PostgreSqlContext(optionsBuilder.Options);
        }
    }

}
