using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.DeleteMedia
{
    internal class DeleteMediaHandler(IMediaListRepository mediaListRepository) : IRequestHandler<DeleteMediaRequest>
    {
        public Task Handle(DeleteMediaRequest request, CancellationToken cancellationToken) =>
            mediaListRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
