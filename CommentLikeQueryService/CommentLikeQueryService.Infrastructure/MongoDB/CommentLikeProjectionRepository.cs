using CommentLikeQueryService.Domain.CommentLikeAggregate;
using MongoDB.Driver;

namespace CommentLikeQueryService.Infrastructure.MongoDB
{
    internal class CommentLikeProjectionRepository(MongoContext context) : ICommentLikeRepository
    {
        public Task<List<CommentLike>> GetByCommentIdAsync(Guid commentId, Guid? cursor, int pageSize, CancellationToken cancellationToken)
        {
            var filter = Builders<CommentLike>.Filter.Eq(x => x.Id.CommentId, commentId);
            if(cursor != null)
               filter &= Builders<CommentLike>.Filter.Lt(x => x.Id.SequenceId, cursor);
            return context.CommentLikes
                .Find(filter)
                .SortByDescending(x => x.Id.SequenceId)
                .Limit(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<CommentLike?> GetByIdAsync(CommentLikeId id, CancellationToken cancellationToken)
        {
            var filter = Builders<CommentLike>.Filter.Eq(x => x.Id, id);
            var result = await context.CommentLikes.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.FirstOrDefaultAsync(cancellationToken);
        }
       
        public Task CreateAsync(CommentLike like, CancellationToken cancellationToken) =>
            context.CommentLikes.InsertOneAsync(like, cancellationToken: cancellationToken);

        public Task DeleteAsync(CommentLike like, CancellationToken cancellationToken) =>
            context.CommentLikes.DeleteOneAsync(Builders<CommentLike>.Filter.Eq(x => x.Id, like.Id), cancellationToken);

        //public async Task UpdateAsync(List<CommentLike> projections, CancellationToken cancellationToken = default)
        //{
        //    if (projections.Count == 0) return;

        //    var updates = new List<WriteModel<CommentLike>>();
        //    foreach (var like in projections)
        //    {
        //        var filter = Builders<CommentLike>.Filter.And(
        //            Builders<CommentLike>.Filter.Eq(c => c.Id, like.Id),
        //            Builders<CommentLike>.Filter.Eq(c => c.Version, like.Version - 1)
        //        );
        //        updates.Add(new ReplaceOneModel<CommentLike>(filter, like));
        //    }
        //    var result = await context.CommentLikes.BulkWriteAsync(updates, cancellationToken: cancellationToken);
        //    if (result.ModifiedCount < projections.Count)
        //        throw new ConcurrencyException();
        //}
    }
}
