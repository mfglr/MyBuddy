using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyProgramInviteService.Domain;

namespace StudyProgramInviteService.Infrastructure.PostgreSql
{
    internal class SPIModelBuilders : IEntityTypeConfiguration<SPI>
    {
        public void Configure(EntityTypeBuilder<SPI> builder)
        {
            builder.HasKey(x => new { x.StudyProgramId, x.UserId });
            builder.Property(x => x.Version).IsConcurrencyToken();
            builder.OwnsMany(x => x.States);
        }
    }
}
