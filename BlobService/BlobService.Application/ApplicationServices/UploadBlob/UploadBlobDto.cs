using Microsoft.AspNetCore.Http;

namespace BlobService.Application.ApplicationServices.UploadBlob
{
    public record UploadBlobDto(string ContainerName, IFormFileCollection Media);
}
