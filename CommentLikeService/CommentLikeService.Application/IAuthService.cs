using Shared.Events;

namespace CommentLikeService.Application
{
    public interface IAuthService
    {
        CurrentUser CurrentUser { get; }
    }
}
