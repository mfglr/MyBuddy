using MediatR;

namespace UserService.Application.UseCases.DeleteMedia
{
    public record DeleteMediaRequest(string BlobName) : IRequest;
}
