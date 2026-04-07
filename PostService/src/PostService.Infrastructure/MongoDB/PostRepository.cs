using MassTransit.MongoDbIntegration;
using MongoDB.Driver;
using PostService.Domain;

namespace PostService.Infrastructure.MongoDB
{
    internal class PostRepository(MongoContext context, MongoDbContext mongoDbContext) : IPostRepository
    {
        public Task<List<Post>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var filter =
                Builders<Post>.Filter.Eq(x => x.UserId, userId);
            return context.Posts.Find(filter).ToListAsync(cancellationToken);
        }

        public async Task<Post?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await context.Posts.FindAsync(Builders<Post>.Filter.Eq(x => x.Id, id), cancellationToken: cancellationToken);
            return await result.FirstOrDefaultAsync(cancellationToken);
        }

        public Task CreateAsync(Post post, CancellationToken cancellationToken) =>
            context.Posts.InsertOneAsync(mongoDbContext.Session, post, cancellationToken: cancellationToken);

        public async Task UpdateAsync(Post post, CancellationToken cancellationToken)
        {
            var filter = Builders<Post>.Filter.Eq(x => x.Id, post.Id) & Builders<Post>.Filter.Eq(x => x.Version, post.Version - 1);
            var result = await context.Posts.ReplaceOneAsync(mongoDbContext.Session, filter, post, cancellationToken: cancellationToken);
            if (result.ModifiedCount <= 0)
                throw new ConflictDetectedException();
        }

        public Task DeleteAsync(Post post, CancellationToken cancellationToken) =>
            context.Posts.DeleteOneAsync(
                mongoDbContext.Session,
                Builders<Post>.Filter.Eq(x => x.Id, post.Id),
                cancellationToken: cancellationToken
            );

        public async Task UpdateAsync(IEnumerable<Post> posts, CancellationToken cancellationToken)
        {
            var updates = new List<WriteModel<Post>>();
            foreach (var post in posts)
            {
                var filter = Builders<Post>.Filter.And(
                    Builders<Post>.Filter.Eq(c => c.Id, post.Id),
                    Builders<Post>.Filter.Eq(c => c.Version, post.Version - 1)
                );
                updates.Add(new ReplaceOneModel<Post>(filter, post));
            }
            var result = await context.Posts.BulkWriteAsync(mongoDbContext.Session, updates, cancellationToken: cancellationToken);
            if (result.ModifiedCount < posts.Count())
                throw new ConflictDetectedException();
        }
    }
}
