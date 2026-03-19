using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServer.Infrastructure.IdentityFramework
{
    internal class SeedRoles : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder
                .HasData(
                    new { Id = "user", Name = "user", NormalizedName = "USER" },
                    new { Id = "admin", Name = "admin", NormalizedName = "ADMIN" }
                );
        }
    }
}
