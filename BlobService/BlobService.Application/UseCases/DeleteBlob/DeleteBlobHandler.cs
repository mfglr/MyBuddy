using MediatR;

namespace BlobService.Application.UseCases.DeleteBlob
{
    internal class DeleteBlobHandler(IBlobService blobService) : IRequestHandler<DeleteBlobRequest>
    {
        private readonly IBlobService _blobService = blobService;

        public Task Handle(DeleteBlobRequest request, CancellationToken cancellationToken) =>
            _blobService.DeleteAsync(request.ContainerName, request.BlobNames, cancellationToken);
    }
}
