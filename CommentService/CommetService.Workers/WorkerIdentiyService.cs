using CommentService.Application;
using Shared.Events;

namespace CommetService.Workers
{
    internal class WorkerIdentiyService : IAuthService
    {
        public CurrentUser CurrentUser => throw new NotImplementedException();
    }
}
