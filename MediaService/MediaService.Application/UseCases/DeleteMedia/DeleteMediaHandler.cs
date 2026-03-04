using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.DeleteMedia
{
    internal class DeleteMediaHandler(IMediaRepository mediaRepository) : IRequestHandler<DeleteMediaRequest>
    {
        public async Task Handle(DeleteMediaRequest request, CancellationToken cancellationToken)
        {
            var media = await mediaRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new MediaNotFoundException();
            await mediaRepository.DeleteAsync(media, cancellationToken);
        }
    }
}
