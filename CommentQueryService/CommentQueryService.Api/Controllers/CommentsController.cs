using CommentQueryService.Application.UseCases;
using CommentQueryService.Application.UseCases.GetByParentId;
using CommentQueryService.Application.UseCases.GetByPostId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommentQueryService.Api.Controllers
{
    [Authorize("comment_query")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CommentsController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public Task<IEnumerable<CommentResponse>> GetByPostId([FromQuery] GetByPostIdRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpGet]
        public Task<IEnumerable<CommentResponse>> GetByParentId([FromQuery] GetByParentIdRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
