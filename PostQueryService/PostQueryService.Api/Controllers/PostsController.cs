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
        //[FromQuery]Guid userId, [FromQuery] DateTime cursor, [FromQuery] int recordsPerPage, [FromQuery] bool isDescending,
        [HttpGet]
        public Task<IEnumerable<PostResponse>> GetByUserId([FromQuery] GetPostsByUserIdRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
