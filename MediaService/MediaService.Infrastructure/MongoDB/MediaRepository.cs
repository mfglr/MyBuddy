using MassTransit.MongoDbIntegration;
using MediaService.Domain;
using MongoDB.Driver;

namespace MediaService.Infrastructure.MongoDB
{
    internal class MediaRepository(MongoContext context, MongoDbContext mongoDbContext) : IMediaRepository
    {
        public async Task<Media> GetByIdAsync(MediaId id, CancellationToken cancellationToken)
        {
            var filter = Builders<Media>.Filter.Eq(x => x.Id, id);
            var result = await context.Media.FindAsync(filter, cancellationToken: cancellationToken);
            return await result.FirstOrDefaultAsync(cancellationToken);
        }

        public Task CreateAsync(IEnumerable<Media> media, CancellationToken cancellationToken) =>
            context.Media.InsertManyAsync(mongoDbContext.Session, media, cancellationToken: cancellationToken);

        public Task DeleteAsync(Media media, CancellationToken cancellationToken) =>
            context.Media.DeleteOneAsync(mongoDbContext.Session, Builders<Media>.Filter.Eq(x => x.Id,media.Id),cancellationToken: cancellationToken);

        public async Task UpdateAsync(Media media, CancellationToken cancellationToken)
        {
            var filter = Builders<Media>.Filter.Eq(x => x.Id, media.Id) & Builders<Media>.Filter.Eq(x => x.Version, media.Version - 1);
            var result = await context.Media.ReplaceOneAsync(mongoDbContext.Session, filter, media, cancellationToken: cancellationToken);
            if (result.ModifiedCount < 1)
                throw new ConflictDetectedException();
        }
    }
}
