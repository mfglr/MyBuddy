using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PostService.Domain;

namespace PostService.Infrastructure.PostgreSql
{
    public class SqlContext(DbContextOptions<SqlContext> options) : DbContext(options)
    {
        public DbSet<Post> Posts { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Version).IsConcurrencyToken();
                entity.OwnsOne(e => e.Content, content => content.OwnsOne(x => x.ModerationResult));
                entity.OwnsMany(e => e.Media, media =>
                {
                    media.OwnsOne(x => x.Metadata);
                    media.OwnsOne(x => x.ModerationResult);
                    media.OwnsMany(x => x.Thumbnails);
                    media.OwnsOne(x => x.Instruction, instruction => {
                        instruction.OwnsOne(x => x.MetadataInstruction);
                        instruction.OwnsOne(x => x.ModerationInstruction);
                        instruction.OwnsMany(x => x.ThumbnailInstructions);
                        instruction.OwnsOne(x => x.TranscodingInstruction);
                    });
                });
            });
        }
    }

    internal class SqlContextFactory : IDesignTimeDbContextFactory<SqlContext>
    {
        public SqlContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=2345;Database=PostDB;Username=postgres;Password=123456789Abc*");
            return new SqlContext(optionsBuilder.Options);
        }
    }
}
