using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostLikeQueryService.Application;
using PostLikeQueryService.Application.UseCases.GetPostLikesByPostId;

namespace PostLikeQueryService.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class PostLikesController(ISender sender) : ControllerBase
    {
        public Task<List<PostLikeResponse>> GetByPostId([FromQuery]GetPostLikesByPostIdRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
