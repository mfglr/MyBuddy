using BlobService.Application.UseCases.CreateContainer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlobService.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ContainersController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        public Task Create(CreateContainerRequest request, CancellationToken cancellationToken) =>
            _sender.Send(request, cancellationToken);
    }
}
