using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaService.Infrastructure.PostgreSql
{
    internal class MediaModelBuilder : IEntityTypeConfiguration<Domain.Media>
    {
        public void Configure(EntityTypeBuilder<Domain.Media> builder)
        {
            builder.HasKey(x => new { x.ContainerName, x.BlobName });
            builder.Property(x => x.Context).HasColumnType("jsonb");
        }
    }
}
