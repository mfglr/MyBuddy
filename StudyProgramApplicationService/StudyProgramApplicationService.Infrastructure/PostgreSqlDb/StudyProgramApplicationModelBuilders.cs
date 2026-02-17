using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyProgramApplicationService.Domain;

namespace StudyProgramApplicationService.Infrastructure.PostgreSqlDb
{
    internal class EnrollmentRequestModelBuilders : IEntityTypeConfiguration<StudyProgramApplication>
    {
        public void Configure(EntityTypeBuilder<StudyProgramApplication> builder)
        {
            builder.Property(x => x.Version).IsConcurrencyToken();
            builder.HasKey(x => new { x.StudyProgramId, x.UserId });
        }
    }
}
