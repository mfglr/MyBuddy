namespace BlobService.Application.ApplicationServices.DeleteBlob
{
    public record DeleteBlobDto(string ContainerName, IEnumerable<string> BlobNames);
}
