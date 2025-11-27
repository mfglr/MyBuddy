using MongoDB.Driver;
using PostService.Domain;

namespace PostService.Infrastructure
{
    internal class PostRepository(MongoContext context) : IPostRepository
    {
        private readonly MongoContext _context = context;

        public Task CreateAsync(Post post, CancellationToken cancellationToken)
            => _context.Posts.InsertOneAsync(post, cancellationToken: cancellationToken);

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Post>.Filter.Eq(c => c.Id, id);
            await _context.Posts.DeleteOneAsync(filter, cancellationToken: cancellationToken);
        }

        public async Task<Post?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Post>.Filter.Eq(c => c.Id, id);
            var documents = await _context.Posts.FindAsync(filter, cancellationToken: cancellationToken);
            return await documents.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task UpdateAsync(Post question, CancellationToken cancellationToken)
        {
            var filter = Builders<Post>.Filter.And(
                Builders<Post>.Filter.Eq(c => c.Id, question.Id),
                Builders<Post>.Filter.Eq(c => c.Version, question.Version - 1)
            );
            var result = await _context.Posts.ReplaceOneAsync(filter, question, cancellationToken: cancellationToken);
            if (result.ModifiedCount == 0)
                throw new AppConcurrencyException();
        }
    }
}
