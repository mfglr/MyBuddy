using CommentQueryService.Shared.Dto;
using CommentQueryService.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommentQueryService.Api.Controllers
{
    [Authorize("comment_query")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CommentsController(ICommentQueryRepository repository) : ControllerBase
    {
        [HttpGet]
        public Task<List<CommentResponse>> GetByPostId([FromQuery] GetByPostIdRequest request, CancellationToken cancellationToken) =>
            repository.GetByPostIdAsync(request.PostId, request.Cursor, request.PageSize, cancellationToken);

        [HttpGet]
        public Task<List<CommentResponse>> GetByParentId([FromQuery] GetByParentIdRequest request, CancellationToken cancellationToken) =>
            repository.GetByParentIdAsync(request.ParentId, request.Cursor, request.PageSize, cancellationToken);
    }
}
