using MassTransit;
using Microsoft.EntityFrameworkCore;
using StudyProgramService.Domain.StudyProgramAggregate.Entities;
using System.Reflection;

namespace StudyProgramService.Infrastructure.PostgreSqlDb
{
    public class PostgreSqlContext(DbContextOptions options) : DbContext(options)
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
}
