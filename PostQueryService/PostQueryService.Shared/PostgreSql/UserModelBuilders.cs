using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostQueryService.Shared.Model;

namespace PostQueryService.Shared.PostgreSql
{
    internal class UserModelBuilders : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Media).HasColumnType("jsonb");
        }
    }
}
