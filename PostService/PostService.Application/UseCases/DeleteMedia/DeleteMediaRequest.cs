namespace PostService.Application.UseCases.DeleteMedia
{
    public record DeleteMediaRequest(Guid Id, string BlobName);
}
