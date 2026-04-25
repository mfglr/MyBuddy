using MassTransit.MongoDbIntegration;
using MongoDB.Driver;
using PostLikeService.Domain;

namespace PostLikeService.Infrastructure.MongoDb
{
    internal class PostLikeRepository(MongoContext context, MongoDbContext mongoDbContext) : IPostLikeRepository
    {
        public Task<PostLike?> GetByIdAsync(PostLikeId id, CancellationToken cancellationToken = default) =>
            context.PostLikes
                .Find(Builders<PostLike>.Filter.Eq(x => x.Id, id))
                .FirstOrDefaultAsync(cancellationToken);

        public Task<List<PostLike>> GetByPostIdAsync(Guid postId, CancellationToken cancellationToken = default) =>
            context.PostLikes
                .Find(Builders<PostLike>.Filter.Eq(x => x.Id.PostId, postId))
                .ToListAsync(cancellationToken);

        public Task<bool> ExistAsync(PostLikeId id, CancellationToken cancellationToken = default) =>
            context.PostLikes
                .Find(Builders<PostLike>.Filter.Eq(x => x.Id, id))
                .AnyAsync(cancellationToken);

        public Task CreateAsync(PostLike postLike, CancellationToken cancellationToken = default) =>
            context.PostLikes
                .InsertOneAsync(mongoDbContext.Session,postLike, cancellationToken: cancellationToken);

        public Task DeleteAsync(PostLike postLike, CancellationToken cancellationToken = default) =>
            context.PostLikes
                .DeleteOneAsync(
                    mongoDbContext.Session,
                    Builders<PostLike>.Filter.Eq(x => x.Id, postLike.Id),
                    cancellationToken: cancellationToken
                );

        public Task DeleteAsync(IEnumerable<PostLike> postLikes, CancellationToken cancellationToken = default) =>
            context.PostLikes
                .DeleteManyAsync(
                    mongoDbContext.Session,
                    Builders<PostLike>.Filter.In(x => x.Id, postLikes.Select(x => x.Id)),
                    cancellationToken: cancellationToken
                );
    }
}
