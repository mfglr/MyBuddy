using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.DeleteMedia
{
    public record DeleteMediaRequest(MediaListId Id) : IRequest;
}
