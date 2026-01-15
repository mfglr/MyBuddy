using MediatR;

namespace BlobService.Application.UseCases.UploadBlob
{
    internal class UploadBlobHandler(IBlobService blobService) : IRequestHandler<UploadBlobRequest, UploadBlobResponse>
    {
        private readonly IBlobService _blobService = blobService;

        public async Task<UploadBlobResponse> Handle(UploadBlobRequest request, CancellationToken cancellationToken)
        {
            var blobNames = await _blobService.UploadAsync(request.ContainerName, request.Media, cancellationToken);
            return new(blobNames);
        }
    }
}
