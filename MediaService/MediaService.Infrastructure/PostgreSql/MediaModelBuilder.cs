using MediaService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaService.Infrastructure.PostgreSql
{
    internal class MediaModelBuilder : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasKey(x => new { x.ContainerName, x.BlobName });
            builder.Property(x => x.Metadata).HasColumnType("jsonb");
            builder.Property(x => x.ModerationResult).HasColumnType("jsonb");
            builder.Property(x => x.Thumbnails).HasColumnType("jsonb");
            builder.Property(x => x.Transcodings).HasColumnType("jsonb");
            builder.Property(x => x.Instruction).HasColumnType("jsonb");
        }
    }
}
