using CommentService.Domain;
using MassTransit.MongoDbIntegration;
using MongoDB.Driver;

namespace CommentService.Infrastructure.MongoDb
{
    internal class CommentRepository(MongoContext context, MongoDbContext mongoDbContext) : ICommentRepository
    {
        public async Task<bool> ExistAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = 
                Builders<Comment>.Filter.Eq(x => x.Id, id) &
                Builders<Comment>.Filter.Eq(x => x.IsDeleted,false);
            var result = await context.Comments.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.AnyAsync(cancellationToken);
        }

        public async Task<Comment?> GetCommentByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Comment>.Filter.Eq(x => x.Id, id);
            var result = await context.Comments.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<Comment?> GetCommentExceptDeletedByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = 
                Builders<Comment>.Filter.Eq(x => x.Id, id) &
                Builders<Comment>.Filter.Eq(x => x.IsDeleted, false);
            var result = await context.Comments.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Comment>> GetCommentsByRepliedIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter =
                Builders<Comment>.Filter.Eq(x => x.RepliedId, id);
            var result = await context.Comments.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.ToListAsync(cancellationToken);
        }
        public async Task<List<Comment>> GetCommentsExceptDeletedByRepliedIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = 
                Builders<Comment>.Filter.Eq(x => x.RepliedId, id) &
                Builders<Comment>.Filter.Eq(x => x.IsDeleted, false);
            var result = await context.Comments.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.ToListAsync(cancellationToken);
        }

        public async Task<List<Comment>> GetCommentsByPostIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter =
                Builders<Comment>.Filter.Eq(x => x.PostId, id);

            var result = await context.Comments.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.ToListAsync(cancellationToken);
        }
        public async Task<List<Comment>> GetCommentsExceptDeletedByPostIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = 
                Builders<Comment>.Filter.Eq(x => x.PostId, id) &
                Builders<Comment>.Filter.Eq(x => x.IsDeleted, false);
            
            var result = await context.Comments.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.ToListAsync(cancellationToken);
        }

        public Task CreateAsync(Comment comment, CancellationToken cancellationToken) =>
            context.Comments.InsertOneAsync(mongoDbContext.Session, comment, cancellationToken: cancellationToken);

        public async Task UpdateAsync(Comment comment, CancellationToken cancellationToken)
        {
            var filter =
                Builders<Comment>.Filter.Eq(x => x.Id, comment.Id) &
                Builders<Comment>.Filter.Eq(x => x.Version, comment.Version - 1);

            var result = await context.Comments.ReplaceOneAsync(mongoDbContext.Session, filter, comment, cancellationToken: cancellationToken);
            if (result.ModifiedCount == 0)
                throw new ConflictDetectedException();
        }

        public async Task UpdateAsync(IEnumerable<Comment> comments, CancellationToken cancellationToken)
        {
            var updates = new List<WriteModel<Comment>>();
            foreach (var comment in comments)
            {
                var filter = Builders<Comment>.Filter.And(
                    Builders<Comment>.Filter.Eq(c => c.Id, comment.Id),
                    Builders<Comment>.Filter.Eq(c => c.Version, comment.Version - 1)
                );
                updates.Add(new ReplaceOneModel<Comment>(filter, comment));
            }
            var result = await context.Comments.BulkWriteAsync(mongoDbContext.Session, updates, cancellationToken: cancellationToken);
            if (result.ModifiedCount < comments.Count())
                throw new ConflictDetectedException();
        }

        public async Task DeleteAsync(Comment comment, CancellationToken cancellationToken)
        {
            var filter =
                Builders<Comment>.Filter.Eq(x => x.Id, comment.Id) &
                Builders<Comment>.Filter.Eq(x => x.Version, comment.Version);
            var result = await context.Comments.DeleteOneAsync(mongoDbContext.Session, filter, cancellationToken: cancellationToken);
            if (result.DeletedCount == 0)
                throw new ConflictDetectedException();
        }
    }
}
