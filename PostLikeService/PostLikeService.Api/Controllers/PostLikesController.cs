using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostLikeService.Application.UseCases.DislikePost;
using PostLikeService.Application.UseCases.LikePost;

namespace PostLikeService.Api.Controllers
{
    [Authorize("user")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class PostLikesController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public Task Like(LikePostRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPost]
        public Task Dislike(DislikePostRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
