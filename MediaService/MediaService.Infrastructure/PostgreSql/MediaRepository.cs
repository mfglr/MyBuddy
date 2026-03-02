using MediaService.Domain;

namespace MediaService.Infrastructure.PostgreSql
{
    internal class MediaRepository(SqlContext context) : IMediaRepository
    {
        public Task<Media?> GetAsync(string containerName, string blobName, CancellationToken cancellationToken) =>
            context.Media.FindAsync([containerName, blobName], cancellationToken).AsTask();

        public Task CreateMedia(IEnumerable<Media> media, CancellationToken cancellationToken) =>
            context.Media.AddRangeAsync(media, cancellationToken);

        public void Delete(Media media) =>
            context.Media.Remove(media);
    }
}
