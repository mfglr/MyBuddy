using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyProgramService.Domain.Entities;

namespace StudyProgramService.Infrastructure.PostgreSqlDb
{
    internal class SPModelBuilders : IEntityTypeConfiguration<SP>
    {
        public void Configure(EntityTypeBuilder<SP> builder)
        {
            builder.Property(x => x.Version).IsConcurrencyToken();
            builder.OwnsOne(x => x.Title);
            builder.OwnsOne(x => x.Description);
            builder.OwnsOne(x => x.DailyStudyTarget);
            builder.OwnsOne(x => x.DaysPerWeek);
            builder.OwnsOne(x => x.DurationInWeeks);
            builder.OwnsOne(x => x.Price,x => x.OwnsOne(x => x.Currency));
            builder.OwnsOne(x => x.EnrollmentStrategy);
        }
    }
}
