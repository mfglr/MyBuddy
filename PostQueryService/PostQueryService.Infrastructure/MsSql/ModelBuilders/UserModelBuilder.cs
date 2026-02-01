using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostQueryService.Domain.UserDomain;

namespace PostQueryService.Infrastructure.MsSql.ModelBuilders
{
    internal class UserModelBuilder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
