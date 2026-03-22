using CommentLikeService.Domain;
using MassTransit.MongoDbIntegration;
using MongoDB.Driver;

namespace CommentLikeService.Infrastructure.MongoDb
{
    internal class CommentLikeRepository(MongoContext context, MongoDbContext mongoDbContext) : ICommentLikeRepository
    {
        public async Task<CommentLike?> GetByIdAsync(CommentLikeId id, CancellationToken cancellationToken)
        {
            var filter = Builders<CommentLike>.Filter.Eq(x => x.Id, id);
            var result = await context.CommentLikes.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.FirstOrDefaultAsync(cancellationToken);
        }

        public Task<List<CommentLike>> GetCommentLikesByCommentIdAsync(Guid commentId, CancellationToken cancellationToken) =>
            context.CommentLikes
                .Find(Builders<CommentLike>.Filter.Eq(x => x.Id.CommentId, commentId))
                .ToListAsync(cancellationToken);

        public Task<List<CommentLike>> GetCommentLikesExceptDeletedAsync(Guid commentId, CancellationToken cancellationToken)
        {
            var filter = 
                Builders<CommentLike>.Filter.Eq(x => x.Id.CommentId, commentId) &
                Builders<CommentLike>.Filter.Eq(x => x.IsDeleted, false);
            return context.CommentLikes.Find(filter).ToListAsync(cancellationToken);
        }

        public Task<bool> ExistAsync(CommentLikeId id, CancellationToken cancellationToken)
        {
            var filter = 
                Builders<CommentLike>.Filter.Eq(x => x.Id, id) &
                Builders<CommentLike>.Filter.Eq(x => x.IsDeleted, false);
            return context.CommentLikes.Find(filter).AnyAsync(cancellationToken);
        }

        public Task CreateAsync(CommentLike postLike, CancellationToken cancellationToken = default) =>
            context.CommentLikes
                .InsertOneAsync(
                    mongoDbContext.Session,
                    postLike,
                    cancellationToken: cancellationToken
                );

        public async Task DeleteAsync(CommentLike postLike, CancellationToken cancellationToken = default)
        {
            var filter = Builders<CommentLike>.Filter.Eq(x => x.Id, postLike.Id);
            var result = await context.CommentLikes
                .DeleteOneAsync(
                    mongoDbContext.Session,
                    filter,
                    cancellationToken: cancellationToken
                );
            if (result.DeletedCount < 1)
                throw new ConcurrencyException();
        }

        public async Task UpdateAsync(CommentLike commentLike, CancellationToken cancellationToken = default)
        {
            var filter = 
                    Builders< CommentLike >.Filter.Eq(x => x.Id, commentLike.Id) &
                    Builders<CommentLike>.Filter.Eq(x => x.Version, commentLike.Version - 1);

            var result = await context.CommentLikes
                .ReplaceOneAsync(
                    mongoDbContext.Session,
                    filter,
                    commentLike,
                    cancellationToken: cancellationToken
                );

            if (result.ModifiedCount < 1)
                throw new ConcurrencyException();
        }

        public async Task UpdateAsync(IEnumerable<CommentLike> commentLikes, CancellationToken cancellationToken = default)
        {
            var updates = new List<WriteModel<CommentLike>>();
            foreach (var like in commentLikes)
            {
                var filter = Builders<CommentLike>.Filter.And(
                    Builders<CommentLike>.Filter.Eq(c => c.Id, like.Id),
                    Builders<CommentLike>.Filter.Eq(c => c.Version, like.Version - 1)
                );
                updates.Add(new ReplaceOneModel<CommentLike>(filter, like));
            }
            var result = await context.CommentLikes.BulkWriteAsync(mongoDbContext.Session, updates, cancellationToken: cancellationToken);
            if (result.ModifiedCount < commentLikes.Count())
                throw new ConcurrencyException();
        }
    }
}
