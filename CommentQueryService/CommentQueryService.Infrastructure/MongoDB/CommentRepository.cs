using CommentQueryService.Domain.CommentAggregate;
using MongoDB.Driver;
using Shared;

namespace CommentQueryService.Infrastructure.MongoDB
{
    internal class CommentRepository(MongoContext context) : ICommentRepository
    {
        public Task<List<Comment>> GetByPostIdAsync(Guid postId, int pageSize, PaginationKey<Guid?> cursor, CancellationToken cancellationToken)
        {
            var filter = Builders<Comment>.Filter.Eq(x => x.PostId, postId);
            if (cursor.Key != null)
                filter &= cursor.IsDescending
                    ? Builders<Comment>.Filter.Lt(x => x.Id, cursor.Key)
                    : Builders<Comment>.Filter.Gt(x => x.Id, cursor.Key);
            return cursor.IsDescending
                ? context.Comments.Find(filter).SortByDescending(x => x.Id).Limit(pageSize).ToListAsync(cancellationToken)
                : context.Comments.Find(filter).SortBy(x => x.Id).Limit(pageSize).ToListAsync(cancellationToken);
        }
        public Task<List<Comment>> GetByParentIdAsync(Guid parentId, int pageSize, PaginationKey<Guid?> cursor, CancellationToken cancellationToken)
        {
            var filter = Builders<Comment>.Filter.Eq(x => x.ParentId, parentId);
            if (cursor.Key != null)
                filter &= cursor.IsDescending
                    ? Builders<Comment>.Filter.Lt(x => x.Id, cursor.Key)
                    : Builders<Comment>.Filter.Gt(x => x.Id, cursor.Key);
            return cursor.IsDescending
                ? context.Comments.Find(filter).SortByDescending(x => x.Id).Limit(pageSize).ToListAsync(cancellationToken)
                : context.Comments.Find(filter).SortBy(x => x.Id).Limit(pageSize).ToListAsync(cancellationToken);
        }

        public Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Comment>.Filter.Eq(x => x.Id, id);
            return context.Comments.Find(filter).FirstOrDefaultAsync(cancellationToken);
        }
        
        public Task<List<Comment>> GetByUserIdAsync(Guid userId, int version, CancellationToken cancellationToken)
        {
            var filter =
                Builders<Comment>.Filter.Eq(x => x.UserId, userId) &
                Builders<Comment>.Filter.Lt(x => x.User.Version, version);
            return context.Comments.Find(filter).ToListAsync(cancellationToken);
        }

        public Task CreateAsync(Comment comment, CancellationToken cancellationToken) =>
            context.Comments.InsertOneAsync(comment, cancellationToken: cancellationToken);

        public async Task UpdateAsync(Comment comment, CancellationToken cancellationToken)
        {
            var filter =
                Builders<Comment>.Filter.Eq(x => x.Id, comment.Id) &
                Builders<Comment>.Filter.Eq(x => x.Version, comment.Version - 1);
            var result = await context.Comments.ReplaceOneAsync(filter, comment, cancellationToken: cancellationToken);
            if (result.ModifiedCount < 1)
                throw new ConcurrencyException();
        }

        public async Task UpdateAsync(IEnumerable<Comment> comments, CancellationToken cancellationToken)
        {
            if (!comments.Any()) return;

            var updates = new List<WriteModel<Comment>>();
            foreach (var comment in comments)
            {
                var filter = Builders<Comment>.Filter.And(
                    Builders<Comment>.Filter.Eq(c => c.Id, comment.Id),
                    Builders<Comment>.Filter.Eq(c => c.Version, comment.Version - 1)
                );
                updates.Add(new ReplaceOneModel<Comment>(filter, comment));
            }
            var result = await context.Comments.BulkWriteAsync(updates, cancellationToken: cancellationToken);
            if (result.ModifiedCount < comments.Count())
                throw new ConcurrencyException();
        }

        public Task DeleteAsync(Comment comment, CancellationToken cancellationToken)
        {
            var filter = Builders<Comment>.Filter.Eq(x => x.Id, comment.Id);
            return context.Comments.DeleteOneAsync(filter,cancellationToken: cancellationToken);
        }


        public Task IncreaseLikeCount(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Comment>.Filter.Eq(x => x.Id, id);
            var update = Builders<Comment>.Update.Inc(x => x.LikeCount, 1);
            return context.Comments.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        }
        public Task DecreaseLikeCount(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Comment>.Filter.Eq(x => x.Id, id);
            var update = Builders<Comment>.Update.Inc(x => x.LikeCount, -1);
            return context.Comments.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        }

        public Task IncreaseChildCount(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Comment>.Filter.Eq(x => x.Id, id);
            var update = Builders<Comment>.Update.Inc(x => x.ChildCount, 1);
            return context.Comments.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        }
        public Task DecreaseChildCount(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Comment>.Filter.Eq(x => x.Id, id);
            var update = Builders<Comment>.Update.Inc(x => x.ChildCount, -1);
            return context.Comments.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        }

        
    }
}
