using Media.Models;

namespace MediaService.Domain
{
    public interface IMediaRepository
    {
        Task<Media?> GetByIdAsync(string containerName, string blobName, CancellationToken cancellationToken);
        Task CreateAsync(IEnumerable<Media> media, CancellationToken cancellationToken);
        void Delete(Media media);

        Task<Media?> SetMetadata(string containerName, string blobName, Metadata metadata, CancellationToken cancellationToken);
        Task<Media?> SetModerationResult(string containerName, string blobName, ModerationResult moderationResult, CancellationToken cancellationToken);
        Task<Media?> AddThumbnail(string containerName, string blobName, Thumbnail thumbnail, CancellationToken cancellationToken);
        Task<Media?> AddTranscoding(string containerName, string blobName, Transcoding transcoding, CancellationToken cancellationToken);
    }
}
