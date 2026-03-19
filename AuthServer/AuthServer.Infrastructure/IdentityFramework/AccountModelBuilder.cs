using AuthServer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServer.Infrastructure.IdentityFramework
{
    internal class AccountModelBuilder : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Ignore(x => x.ConcurrencyStamp);
            builder.Property(x => x.Version).IsConcurrencyToken();
            builder.OwnsOne(x => x.Name);
            builder.OwnsOne(
                x => x.Gender,
                gender => gender.Property(x => x.Value).HasDefaultValue("unkown")
            );
        }
    }
}
