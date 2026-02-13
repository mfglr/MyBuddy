using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostLikeQueryService.Domain.PostLikeAggregate;

namespace PostLikeQueryService.Infrastructure.PostgreSql
{
    internal class PostLikeModelBuilders : IEntityTypeConfiguration<PostLike>
    {
        public void Configure(EntityTypeBuilder<PostLike> builder)
        {
            builder
                .Property(x => x.ConcurrencyToken)
                .IsConcurrencyToken();
            builder
                .HasIndex(x => new { x.PostId, x.Id })
                .IsDescending(false, true);
            builder
                .HasIndex(x => new { x.PostId, x.UserId })
                .IsUnique();
        }
    }
}
