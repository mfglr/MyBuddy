using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostQueryService.Application.UseCases;
using PostQueryService.Application.UseCases.GetById;

namespace PostQueryService.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class PostsController(ISender sender) : ControllerBase
    {
        [HttpGet("{id}")]
        public Task<PostProjectionResponse> GetById(string id, CancellationToken cancellationToken) =>
            sender.Send(new GetByIdRequest(id), cancellationToken);
    }
}
