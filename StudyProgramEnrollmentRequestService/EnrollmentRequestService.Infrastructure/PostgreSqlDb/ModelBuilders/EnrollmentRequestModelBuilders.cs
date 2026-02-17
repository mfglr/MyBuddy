using EnrollmentRequestService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnrollmentRequestService.Infrastructure.PostgreSqlDb.ModelBuilders
{
    internal class EnrollmentRequestModelBuilders : IEntityTypeConfiguration<EnrollmentRequest>
    {
        public void Configure(EntityTypeBuilder<EnrollmentRequest> builder)
        {
            builder.Property(x => x.Version).IsConcurrencyToken();
            builder.HasKey(x => new { x.StudyProgramId, x.UserId });
            builder.OwnsOne(x => x.Status);
        }
    }
}
