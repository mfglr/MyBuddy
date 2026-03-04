using MassTransit.MongoDbIntegration;
using MongoDB.Driver;
using PostService.Domain;

namespace PostService.Infrastructure.MongoDB
{
    internal class PostRepository(MongoContext context, MongoDbContext mongoDbContext) : IPostRepository
    {
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

        public Task Delete(Post post, CancellationToken cancellationToken) =>
            context.Posts.DeleteOneAsync(
                mongoDbContext.Session,
                Builders<Post>.Filter.Eq(x => x.Id, post.Id),
                cancellationToken: cancellationToken
            );
    }
}
