using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostQueryService.Application.UseCases;
using PostQueryService.Application.UseCases.GetById;
using PostQueryService.Application.UseCases.GetByUserId;
using PostQueryService.Application.UseCases.SearchPosts;

namespace PostQueryService.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class PostsController(ISender sender) : ControllerBase
    {
        [HttpGet("{id}")]
        public Task<PostProjectionResponse> GetById(string id, CancellationToken cancellationToken) =>
            sender.Send(new GetByIdRequest(id), cancellationToken);

        [HttpGet]
        public Task<IEnumerable<PostProjectionResponse>> GetByUserId([FromQuery] GetByUserIdRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpGet]
        public Task<IEnumerable<PostProjectionResponse>> Search([FromQuery] SearchPostsRequest request,CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
