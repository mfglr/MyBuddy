namespace ThumbnailGenerator.Application
{
    public interface IBlobService
    {
        Task<string> UploadAsync(Stream stream, string containerName, CancellationToken cancellationToken);
        Task<Stream> GetAsync(string containerName, string blobName, CancellationToken cancellationToken);
        Task DeleteAsync(string containerName, string blobName, CancellationToken cancellationToken);
    }
}
