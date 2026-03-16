using CommentQueryService.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommentQueryService.Shared.PostgreSql
{
    internal class CommentModelBuilder : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasIndex(x => new { x.PostId, x.Id }).IsDescending(false, true);
            builder.HasIndex(x => new { x.ParentId, x.Id }).IsDescending(false, true);
            builder.OwnsOne(x => x.Content, x => x.Property(x => x.ModerationResult).HasColumnType("jsonb"));
        }
    }
}
