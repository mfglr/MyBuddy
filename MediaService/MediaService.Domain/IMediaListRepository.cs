using Shared.Events.SharedObjects;

namespace MediaService.Domain
{
    public interface IMediaListRepository
    {
        Task CreateAsync(MediaList mediaList, CancellationToken cancellationToken);
        Task<MediaList> SetMetadata(MediaListId id, string blobName, Metadata metadata, CancellationToken cancellationToken);
        Task<MediaList> SetModerationResult(MediaListId id, string blobName, ModerationResult? moderationResult, CancellationToken cancellationToken);
        Task<MediaList> SetThumbnails(MediaListId id, string blobName, IEnumerable<Thumbnail> thumbnails, CancellationToken cancellationToken);
        Task<MediaList> SetTranscodedBlobName(MediaListId id, string blobName, string transcodedBlobName, CancellationToken cancellationToken);
        Task DeleteAsync(MediaListId id, CancellationToken cancellationToken);
    }
}
