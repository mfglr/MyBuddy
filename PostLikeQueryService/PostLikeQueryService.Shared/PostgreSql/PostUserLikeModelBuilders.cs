using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostLikeQueryService.Shared.Model;

namespace PostLikeQueryService.Shared.PostgreSql
{
    internal class PostUserLikeModelBuilders : IEntityTypeConfiguration<PostUserLike>
    {
        public void Configure(EntityTypeBuilder<PostUserLike> builder)
        {
            builder.HasKey(x => new { x.PostId, x.SequenceId, x.UserId });
        }
    }
}
