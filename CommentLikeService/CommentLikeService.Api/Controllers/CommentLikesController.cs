using CommentLikeService.Application.UseCases.DislikeComment;
using CommentLikeService.Application.UseCases.LikeComment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommentLikeService.Api.Controllers
{
    [Authorize("user")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CommentLikesController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public Task Like(LikeCommentRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPost]
        public Task Dislike(DislikeCommentRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
