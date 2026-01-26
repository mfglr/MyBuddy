using Microsoft.AspNetCore.Http;

namespace UserService.Application
{
    public interface IBlobService
    {
        Task<string> UploadAsync(string containerName, IFormFile file, CancellationToken cancellationToken);
        Task DeleteAsync(string containerName, string blobName, CancellationToken cancellationToken);
    }
}
