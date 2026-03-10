using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.DeleteMedia
{
    internal class DeleteMediaHandler(IMediaRepository mediaRepository) : IRequestHandler<DeleteMediaRequest>
    {
        public async Task Handle(DeleteMediaRequest request, CancellationToken cancellationToken)
        {
            var media = await mediaRepository.GetByIdAsync(request.ContainerName, request.BlobName, cancellationToken) ?? throw new MediaNotFoundException();
            mediaRepository.Delete(media);
        }
    }
}
