using CommentLikeQueryService.Domain;
using MongoDB.Driver;

namespace CommentLikeQueryService.Infrastructure.MongoDB
{
    internal class CommentLikeProjectionRepository(MongoContext context) : ICommentLikeProjectionRepository
    {
        public Task<List<CommentLikeProjection>> GetByCommentIdAsync(Guid commentId, Guid? cursor, int pageSize, CancellationToken cancellationToken)
        {
            var filter = 
                Builders<CommentLikeProjection>.Filter.Eq(x => x.Id.CommentId, commentId) &
                Builders<CommentLikeProjection>.Filter.Eq(x => x.CommentLike.IsDeleted, false);
            if(cursor != null)
               filter &= Builders<CommentLikeProjection>.Filter.Lt(x => x.Id.SequenceId, cursor);
            return context.CommentLikes
                .Find(filter)
                .SortByDescending(x => x.Id.SequenceId)
                .Limit(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<CommentLikeProjection> GetByIdAsync(ProjectionId id, CancellationToken cancellationToken)
        {
            var filter = Builders<CommentLikeProjection>.Filter.Eq(x => x.Id, id);
            var result = await context.CommentLikes.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.FirstOrDefaultAsync(cancellationToken);
        }

        public Task<List<CommentLikeProjection>> GetByUserAsync(User user, CancellationToken cancellationToken)
        {
            var filter =
                Builders<CommentLikeProjection>.Filter.Eq(x => x.User.Id, user.Id) &
                Builders<CommentLikeProjection>.Filter.Lt(x => x.Version, user.Version);
            return context.CommentLikes.Find(filter).ToListAsync(cancellationToken);
        }

        public Task CreateAsync(CommentLikeProjection projection, CancellationToken cancellationToken) =>
            context.CommentLikes.InsertOneAsync(projection, cancellationToken: cancellationToken);

        public async Task UpdateAsync(CommentLikeProjection projection, CancellationToken cancellationToken = default)
        {
            var filter = 
                    Builders<CommentLikeProjection>.Filter.Eq(x => x.Id, projection.Id) &
                    Builders<CommentLikeProjection>.Filter.Eq(x => x.Version, projection.Version - 1);
            var result = await context.CommentLikes.ReplaceOneAsync(filter,projection,cancellationToken: cancellationToken);
            if (result.ModifiedCount < 1)
                throw new ConcurrencyException();
        }

        public async Task UpdateAsync(List<CommentLikeProjection> projections, CancellationToken cancellationToken = default)
        {
            if (projections.Count == 0) return;

            var updates = new List<WriteModel<CommentLikeProjection>>();
            foreach (var like in projections)
            {
                var filter = Builders<CommentLikeProjection>.Filter.And(
                    Builders<CommentLikeProjection>.Filter.Eq(c => c.Id, like.Id),
                    Builders<CommentLikeProjection>.Filter.Eq(c => c.Version, like.Version - 1)
                );
                updates.Add(new ReplaceOneModel<CommentLikeProjection>(filter, like));
            }
            var result = await context.CommentLikes.BulkWriteAsync(updates, cancellationToken: cancellationToken);
            if (result.ModifiedCount < projections.Count)
                throw new ConcurrencyException();
        }
    }
}
