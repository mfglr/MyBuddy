using Microsoft.AspNetCore.Http;

namespace BlobService.Application.ApplicationServices.UploadSingleBlob
{
    public record UploadSingleBlobDto(string ContainerName, string BlobName, IFormFile Media);
}
