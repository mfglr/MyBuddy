using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostQueryService.Domain.PostDomain;

namespace PostQueryService.Infrastructure.MsSql.ModelBuilders
{
    internal class PostModelBuilder : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder
                .HasIndex(x => new { x.UserId, x.CreatedAt })
                .IsDescending(false, true);

            builder.OwnsOne(p => p.Content, b => b.OwnsOne(c => c.ModerationResult));
        }
    }
}
