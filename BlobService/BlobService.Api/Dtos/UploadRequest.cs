namespace BlobService.Api.Dtos
{
    public record UploadRequest(
        string ContainerName,
        IFormFileCollection Media
    );
}
