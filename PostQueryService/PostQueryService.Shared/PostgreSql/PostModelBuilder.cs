using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostQueryService.Shared.Model;

namespace PostQueryService.Shared.PostgreSql
{
    internal class PostModelBuilder : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasIndex(x => new { x.UserId, x.Id }).IsDescending(false, true);
            builder.OwnsOne(p => p.Content, b => b.Property(x => x.ModerationResult).HasColumnType("jsonb").IsRequired(false));
            builder.Property(x => x.Media).HasColumnType("jsonb");
        }
    }
}
