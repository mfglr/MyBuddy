using MediatR;

namespace BlobService.Application.UseCases.GetBlob
{
    internal class GetBlobHandler(IBlobService blobService) : IRequestHandler<GetBlobRequest, GetBlobResponse>
    {
        private readonly IBlobService _blobService = blobService;

        public async Task<GetBlobResponse> Handle(GetBlobRequest request, CancellationToken cancellationToken)
        {
            var stream = await _blobService.ReadAsync(request.ContainerName, request.BlobName, cancellationToken);
            return new(stream);
        }
    }
}
