using Microsoft.AspNetCore.Mvc;
using PostQueryService.Shared.Model;

namespace PostQueryService.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class PostsController(IPostRepository postRepository, IPostQueryRepository postQueryRepository) : ControllerBase
    {
        [HttpGet]
        public Task<List<PostResponse>> GetByUserId([FromQuery] GetByUserIdRequest request, CancellationToken cancellationToken) =>
            postQueryRepository.GetByUserId(request.UserId, request.Cursor, request.PageSize, cancellationToken);

        public record TestRequest(Guid Id, int Version);

        [HttpPost]
        public async Task Test(TestRequest request,CancellationToken cancellationToken)
        {
            await postRepository.IncreaseLikeCount(request.Id,cancellationToken);

            //var post = await postRepository.GetByIdAsync(request.Id, cancellationToken);
            //post.Update(request.Version);
            //await postRepository.UpsertAsync(post, cancellationToken);
        }
    }
}
