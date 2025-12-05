using MediaService.Domain;
using MongoDB.Driver;

namespace MediaService.Infrastructure
{
    internal class MediaRepository(MongoContext context) : IMediaRepository
    {
        private readonly MongoContext _context = context;

        public Task CreateAsync(Media media, CancellationToken cancellationToken) =>
            _context.Media.InsertOneAsync(media, cancellationToken: cancellationToken);

        public Task CreateRangeAsync(IEnumerable<Media> media, CancellationToken cancellationToken) =>
            _context.Media.InsertManyAsync(media, cancellationToken: cancellationToken);

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Media>.Filter.Eq(c => c.Id, id);
            await _context.Media.DeleteOneAsync(filter, cancellationToken: cancellationToken);
        }

        public async Task<Media?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Media>.Filter.Eq(c => c.Id, id);
            var documents = await _context.Media.FindAsync(filter, cancellationToken: cancellationToken);
            return await documents.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task UpdateAsync(Media media, CancellationToken cancellationToken)
        {
            var filter = Builders<Media>.Filter.And(
                Builders<Media>.Filter.Eq(c => c.Id, media.Id),
                Builders<Media>.Filter.Eq(c => c.Version, media.Version - 1)
            );
            var result = await _context.Media.ReplaceOneAsync(filter, media, cancellationToken: cancellationToken);
            if (result.ModifiedCount == 0)
                throw new AppConcurrencyException();
        }
    }
}
