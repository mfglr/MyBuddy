using CommentLikeQueryService.Application;
using CommentLikeQueryService.Application.UseCases.GetByCommentId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CommentLikeQueryService.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CommentLikesController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public Task<List<CommentLikeResponse>> GetByCommentId([FromQuery]GetByCommentIdRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
