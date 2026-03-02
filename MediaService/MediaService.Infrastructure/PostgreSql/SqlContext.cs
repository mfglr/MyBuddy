using MassTransit;
using MediaService.Domain;
using Microsoft.EntityFrameworkCore;

namespace MediaService.Infrastructure.PostgreSql
{
    public class SqlContext(DbContextOptions<SqlContext> options) : DbContext(options)
    {
        public DbSet<Media> Media { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();

            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasKey(e => new { e.ContainerName, e.BlobName });
                entity.Property(e => e.Version).IsConcurrencyToken();
                entity.OwnsOne(e => e.Metadata);
                entity.OwnsOne(e => e.ModerationResult);
                entity.OwnsMany(e => e.Thumbnails);
                entity.OwnsOne(e => e.Instruction, instruction =>
                {
                    instruction.OwnsOne(i => i.MetadataInstruction);
                    instruction.OwnsOne(i => i.ModerationInstruction);
                    instruction.OwnsMany(i => i.ThumbnailInstructions);
                    instruction.OwnsOne(i => i.TranscodingInstruction);
                });
            });
        }
    }
}