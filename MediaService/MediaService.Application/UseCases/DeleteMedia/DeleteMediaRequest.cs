using MediatR;

namespace MediaService.Application.UseCases.DeleteMedia
{
    public record DeleteMediaRequest(string ContainerName, string BlobName) : IRequest;
}
