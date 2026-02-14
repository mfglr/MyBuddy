using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostQueryService.Application.QueryRepositories;
using PostQueryService.Application.UseCases.GetPostsByUserId;

namespace PostQueryService.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class PostsController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public Task<IEnumerable<PostResponse>> GetByUserId([FromQuery] GetPostsByUserIdRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
