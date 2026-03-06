using Microsoft.AspNetCore.Mvc;
using PostQueryService.Shared.Model;

namespace PostQueryService.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class PostsController(IPostQueryRepository postQueryRepository) : ControllerBase
    {
        [HttpGet]
        public Task<List<PostResponse>> GetByUserId([FromQuery] GetByUserIdRequest request, CancellationToken cancellationToken) =>
            postQueryRepository.GetByUserId(request.UserId, request.Cursor, request.PageSize, cancellationToken);
    }
}
