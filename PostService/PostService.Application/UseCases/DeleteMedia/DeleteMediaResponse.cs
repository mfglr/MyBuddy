namespace PostService.Application.UseCases.DeleteMedia
{
    public record DeleteMediaResponse(string ContainerName, IReadOnlyList<string> BlobNames);
}
