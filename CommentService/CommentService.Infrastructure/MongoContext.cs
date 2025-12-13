using CommentService.Domain;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CommentService.Infrastructure
{
    internal class MongoContext(DbContextOptions<MongoContext> options) : DbContext(options)
    {
        public DbSet<Comment> Comments { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>().HasIndex(x => x.RepliedId);
            modelBuilder.Entity<Comment>().HasIndex(x => x.PostId);
            modelBuilder.Entity<Comment>().Property(x => x.Version).IsConcurrencyToken();
            modelBuilder.Entity<Comment>().ToCollection("comments");
        }
    }
}
