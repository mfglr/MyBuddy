using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PostLikeQueryService.Api.Controllers
{
    [Authorize("post_like_query")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class PostLikesController() : ControllerBase
    {
        
    }
}
