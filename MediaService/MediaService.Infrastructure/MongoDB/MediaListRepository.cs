using MassTransit.MongoDbIntegration;
using MediaService.Domain;
using MongoDB.Driver;
using Shared.Events.SharedObjects;

namespace MediaService.Infrastructure.MongoDB
{
    internal class MediaListRepository(MongoContext context, MongoDbContext mongoDbContext) : IMediaListRepository
    {
        public Task CreateAsync(MediaList mediaList, CancellationToken cancellationToken) =>
            context.MediaLists.InsertOneAsync(mongoDbContext.Session, mediaList, cancellationToken: cancellationToken);

        public Task<MediaList> SetMetadata(MediaListId id, string blobName, Metadata metadata, CancellationToken cancellationToken) =>
            ApplyUpdate(
                id,
                blobName,
                () => Builders<MediaList>.Update.Set("Items.$.Metadata", metadata),
                cancellationToken
            );

        public Task<MediaList> SetModerationResult(MediaListId id, string blobName, ModerationResult? moderationResult, CancellationToken cancellationToken) =>
            ApplyUpdate(
                id,
                blobName,
                () => Builders<MediaList>.Update.Set("Items.$.ModerationResult", moderationResult),
                cancellationToken
            );

        public Task<MediaList> SetThumbnails(MediaListId id, string blobName, IEnumerable<Thumbnail> thumbnails, CancellationToken cancellationToken) =>
            ApplyUpdate(
                id,
                blobName,
                () => Builders<MediaList>.Update.Set("Items.$.Thumbnails", thumbnails),
                cancellationToken
            );

        public Task<MediaList> SetTranscodedBlobName(MediaListId id, string blobName, string transcodedBlobName, CancellationToken cancellationToken) =>
            ApplyUpdate(
                id,
                blobName,
                () => Builders<MediaList>.Update.Set("Items.$.TranscodedBlobName", transcodedBlobName),
                cancellationToken
            );

        public Task DeleteAsync(MediaListId id, CancellationToken cancellationToken) =>
            context.MediaLists.DeleteOneAsync(
                mongoDbContext.Session,
                Builders<MediaList>.Filter.Eq(x => x.Id, id),
                cancellationToken: cancellationToken
            );

        private Task<MediaList> ApplyUpdate(MediaListId id, string blobName, Func<UpdateDefinition<MediaList>> update, CancellationToken cancellationToken)
        {
            var filter = Builders<MediaList>.Filter.And(
                Builders<MediaList>.Filter.Eq(x => x.Id, id),
                Builders<MediaList>.Filter.ElemMatch(x => x.Items, i => i.BlobName == blobName)
            );
            var options = new FindOneAndUpdateOptions<MediaList>
            {
                ReturnDocument = ReturnDocument.After
            };
            return context.MediaLists.FindOneAndUpdateAsync(mongoDbContext.Session, filter, update(), options: options, cancellationToken: cancellationToken);
        }
    }
}
