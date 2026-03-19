using Microsoft.AspNetCore.Http;

namespace AuthServer.Application
{
    public interface IBlobService
    {
        Task<string> UploadAsync(string containerName, IFormFile file, CancellationToken cancellationToken);
        Task DeleteAsync(string containerName, string blobName, CancellationToken cancellationToken);
    }
}
