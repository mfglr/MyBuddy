using MongoDB.Driver;
using PostLikeService.Domain;

namespace PostLikeService.Infrastructure.MongoDb
{
    internal class PostLikeRepository(MongoContext context) : IPostLikeRepository
    {
        public Task<PostLike?> GetAsync(PostLikeId id, CancellationToken cancellationToken) =>
            context.PostLikes
                .Find(Builders<PostLike>.Filter.Eq(x => x.Id, id))
                .FirstOrDefaultAsync(cancellationToken);

        public Task<bool> ExistAsync(PostLikeId id, CancellationToken cancellationToken) =>
            context.PostLikes
                .Find(Builders<PostLike>.Filter.Eq(x => x.Id, id))
                .AnyAsync(cancellationToken);

        public Task CreateAsync(PostLike postLike, CancellationToken cancellationToken = default) =>
            context.PostLikes
                .InsertOneAsync(postLike, cancellationToken: cancellationToken);

        public Task DeleteAsync(PostLike postLike, CancellationToken cancellationToken = default) =>
            context.PostLikes
                .DeleteOneAsync(Builders<PostLike>.Filter.Eq(x => x.Id, postLike.Id), cancellationToken);
    }
}
