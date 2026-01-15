using BlobService.Application.UseCases.DeleteBlob;
using BlobService.Application.UseCases.GetBlob;
using BlobService.Application.UseCases.UploadBlob;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlobService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlobsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [RequestSizeLimit(104857600)]
        [HttpPost]
        public async Task<IEnumerable<string>> Upload([FromForm]string containerName, [FromForm]IFormFileCollection media, CancellationToken cancellationToken) =>
            (await _sender.Send(new UploadBlobRequest(containerName, media),cancellationToken)).BlobNames;

        [HttpPost]
        public Task Delete(DeleteBlobRequest request, CancellationToken cancellationToken)
             => _sender.Send(request,cancellationToken);

        [HttpGet("{containerName}/{blobName}")]
        public async Task<Stream> Get(string containerName, string blobName, CancellationToken cancellationToken) =>
            (await _sender.Send(new GetBlobRequest(containerName, blobName), cancellationToken)).Stream;
    }
}
