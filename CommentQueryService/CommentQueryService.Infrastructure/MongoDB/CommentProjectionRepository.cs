using CommentQueryService.Domain;
using MongoDB.Driver;

namespace CommentQueryService.Infrastructure.MongoDB
{
    internal class CommentProjectionRepository(MongoContext context) : ICommentProjectionRepository
    {
        public Task<List<CommentProjection>> GetByPostIdAsync(Guid postId, Guid? cursor, int pageSize, CancellationToken cancellationToken)
        {
            var filter = Builders<CommentProjection>.Filter.Eq(x => x.Comment.PostId, postId);
            if (cursor != null)
                filter &= Builders<CommentProjection>.Filter.Lt(x => x.Id, cursor);
            return context.Comments.Find(filter).SortByDescending(x => x.Id).Limit(pageSize).ToListAsync(cancellationToken);
        }
        public Task<List<CommentProjection>> GetByParentIdAsync(Guid parentId, Guid? cursor, int pageSize, CancellationToken cancellationToken)
        {
            var filter = Builders<CommentProjection>.Filter.Eq(x => x.Comment.ParentId, parentId);
            if (cursor != null)
                filter &= Builders<CommentProjection>.Filter.Lt(x => x.Id, cursor);
            return context.Comments.Find(filter).SortByDescending(x => x.Id).Limit(pageSize).ToListAsync(cancellationToken);
        }

        public Task<CommentProjection?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<CommentProjection>.Filter.Eq(x => x.Id, id);
            return context.Comments.Find(filter).FirstOrDefaultAsync(cancellationToken);
        }
        
        public Task<List<CommentProjection>> GetByUserAsync(User user, CancellationToken cancellationToken)
        {
            var filter =
                Builders<CommentProjection>.Filter.Eq(x => x.User.Id, user.Id) &
                Builders<CommentProjection>.Filter.Lt(x => x.User.Version, user.Version);
            return context.Comments.Find(filter).ToListAsync(cancellationToken);
        }

        public Task CreateAsync(CommentProjection comment, CancellationToken cancellationToken) =>
            context.Comments.InsertOneAsync(comment, cancellationToken: cancellationToken);

        public async Task UpdateAsync(CommentProjection comment, CancellationToken cancellationToken)
        {
            var filter =
                Builders<CommentProjection>.Filter.Eq(x => x.Id, comment.Id) &
                Builders<CommentProjection>.Filter.Eq(x => x.Version, comment.Version - 1);
            var result = await context.Comments.ReplaceOneAsync(filter, comment, cancellationToken: cancellationToken);
            if (result.ModifiedCount < 1)
                throw new ConcurrencyException();
        }

        public async Task UpdateAsync(IEnumerable<CommentProjection> comments, CancellationToken cancellationToken)
        {
            var updates = new List<WriteModel<CommentProjection>>();
            foreach (var comment in comments)
            {
                var filter = Builders<CommentProjection>.Filter.And(
                    Builders<CommentProjection>.Filter.Eq(c => c.Id, comment.Id),
                    Builders<CommentProjection>.Filter.Eq(c => c.Version, comment.Version - 1)
                );
                updates.Add(new ReplaceOneModel<CommentProjection>(filter, comment));
            }
            var result = await context.Comments.BulkWriteAsync(updates, cancellationToken: cancellationToken);
            if (result.ModifiedCount < comments.Count())
                throw new ConcurrencyException();
        }

        public Task IncreaseLikeCount(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<CommentProjection>.Filter.Eq(x => x.Id, id);
            var update = Builders<CommentProjection>.Update.Inc(x => x.LikeCount, 1);
            return context.Comments.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        }
        public Task DecreaseLikeCount(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<CommentProjection>.Filter.Eq(x => x.Id, id);
            var update = Builders<CommentProjection>.Update.Inc(x => x.LikeCount, -1);
            return context.Comments.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        }

        public Task IncreaseChildCount(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<CommentProjection>.Filter.Eq(x => x.Id, id);
            var update = Builders<CommentProjection>.Update.Inc(x => x.ChildCount, 1);
            return context.Comments.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        }
        public Task DecreaseChildCount(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<CommentProjection>.Filter.Eq(x => x.Id, id);
            var update = Builders<CommentProjection>.Update.Inc(x => x.ChildCount, -1);
            return context.Comments.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        }
    }
}
