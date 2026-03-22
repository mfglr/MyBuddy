using Shared.Events;

namespace CommentService.Application
{
    public interface IAuthService
    {
        CurrentUser CurrentUser { get; }
    }
}
