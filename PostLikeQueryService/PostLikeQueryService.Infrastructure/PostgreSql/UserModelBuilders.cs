using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostLikeQueryService.Domain.UserAggregate;

namespace PostLikeQueryService.Infrastructure.PostgreSql
{
    internal class UserModelBuilders : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.ConcurrencyToken).IsConcurrencyToken();
        }
    }
}
