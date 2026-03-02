using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.DeleteMedia
{
    internal class DeleteMediaHandler(IMediaRepository mediaRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteMediaRequest>
    {
        public async Task Handle(DeleteMediaRequest request, CancellationToken cancellationToken)
        {
            var media = await mediaRepository.GetAsync(request.ContainerName, request.BlobName, cancellationToken) ?? throw new MediaNotFoundException();
            mediaRepository.Delete(media);
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
