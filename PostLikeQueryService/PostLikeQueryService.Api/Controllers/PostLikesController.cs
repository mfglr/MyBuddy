using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostLikeQueryService.Shared.Dto;
using PostLikeQueryService.Shared.Model;

namespace PostLikeQueryService.Api.Controllers
{
    [Authorize("post_like_query")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class PostLikesController(IPostUserLikeQueryRepository repository) : ControllerBase
    {
        public Task<List<PostUserLikeResponse>> GetByPostId([FromQuery]GetByPostIdRequest request, CancellationToken cancellationToken) =>
            repository.GetByPostId(request.PostId, request.Cursor, request.PageSize, cancellationToken);
    }
}
