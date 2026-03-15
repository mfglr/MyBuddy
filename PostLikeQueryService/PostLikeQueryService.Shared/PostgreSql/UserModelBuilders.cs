using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostLikeQueryService.Shared.Model;

namespace PostLikeQueryService.Shared.PostgreSql
{
    internal class UserModelBuilders : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Media).HasColumnType("jsonb");
        }
    }
}
