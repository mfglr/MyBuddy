using CommentService.Domain;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CommentService.Infrastructure.EfCore
{
    internal class EfCoreMongoContext(DbContextOptions<EfCoreMongoContext> options) : DbContext(options)
    {
        public DbSet<Comment> Comments { get; init; }

        public static EfCoreMongoContext Create(IMongoDatabase database) =>
            new(
                new DbContextOptionsBuilder<EfCoreMongoContext>()
                    .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName).Options
            );

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comment>().ToCollection("comments");
        }
    }
}
