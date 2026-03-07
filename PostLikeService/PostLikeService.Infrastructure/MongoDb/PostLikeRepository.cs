using MassTransit.MongoDbIntegration;
using MongoDB.Driver;
using PostLikeService.Domain;

namespace PostLikeService.Infrastructure.MongoDb
{
    internal class PostLikeRepository(MongoContext context, MongoDbContext mongoDbContext) : IPostLikeRepository
    {
        public Task<PostLike?> GetAsync(PostLikeId id, CancellationToken cancellationToken) =>
            context.PostLikes
                .Find(Builders<PostLike>.Filter.Eq(x => x.Id, id))
                .FirstOrDefaultAsync(cancellationToken);

        public Task<List<PostLike>> GetByPostIdAsync(Guid postId, CancellationToken cancellationToken) =>
            context.PostLikes
                .Find(Builders<PostLike>.Filter.Eq(x => x.Id.PostId, postId))
                .ToListAsync(cancellationToken);

        public Task<bool> ExistAsync(PostLikeId id, CancellationToken cancellationToken) =>
            context.PostLikes
                .Find(Builders<PostLike>.Filter.Eq(x => x.Id, id))
                .AnyAsync(cancellationToken);

        public Task CreateAsync(PostLike postLike, CancellationToken cancellationToken = default) =>
            context.PostLikes
                .InsertOneAsync(mongoDbContext.Session,postLike, cancellationToken: cancellationToken);

        public Task DeleteAsync(PostLike postLike, CancellationToken cancellationToken = default) =>
            context.PostLikes
                .DeleteOneAsync(mongoDbContext.Session, Builders<PostLike>.Filter.Eq(x => x.Id, postLike.Id), cancellationToken: cancellationToken);

        public async Task UpdateAsync(IEnumerable<PostLike> postLikes, CancellationToken cancellationToken = default)
        {
            var updates = new List<WriteModel<PostLike>>();
            foreach (var like in postLikes)
            {
                var filter = Builders<PostLike>.Filter.And(
                    Builders<PostLike>.Filter.Eq(c => c.Id, like.Id),
                    Builders<PostLike>.Filter.Eq(c => c.Version, like.Version - 1)
                );
                updates.Add(new ReplaceOneModel<PostLike>(filter, like));
            }
            var result = await context.PostLikes.BulkWriteAsync(mongoDbContext.Session, updates, cancellationToken: cancellationToken);
            if (result.ModifiedCount < postLikes.Count())
                throw new ConcurrencyException();
        }

        public async Task UpdateAsync(PostLike postLike, CancellationToken cancellationToken = default)
        {
            var result = await context.PostLikes
                .ReplaceOneAsync(
                    mongoDbContext.Session,
                    Builders<PostLike>.Filter.Eq(x => x.Id, postLike.Id) &
                    Builders<PostLike>.Filter.Eq(x => x.Version, postLike.Version - 1),
                    postLike,
                    cancellationToken: cancellationToken
                );

            if(result.ModifiedCount < 1)
                throw new ConcurrencyException();
        }
    }
}
