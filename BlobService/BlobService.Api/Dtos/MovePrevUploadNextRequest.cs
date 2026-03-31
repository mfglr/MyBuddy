namespace BlobService.Api.Dtos
{
    public record MovePrevUploadNextRequest(IFormFile Media, string ContainerName, string BlobName);
}
