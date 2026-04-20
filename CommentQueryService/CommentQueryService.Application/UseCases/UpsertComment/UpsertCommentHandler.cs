using CommentQueryService.Domain.CommentAggregate;
using CommentQueryService.Domain.UserAggregate;
using MediatR;

namespace CommentQueryService.Application.UseCases.UpsertComment
{
    internal class UpsertCommentHandler(
        ICommentRepository commentRepository,
        IUserRepository userRepository,
        UpsertCommentMapper mapper
    ) : IRequestHandler<UpsertCommentRequest>
    {
        public async Task Handle(UpsertCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = await commentRepository.GetByIdAsync(request.Id, cancellationToken);
            if(comment == null)
            {
                var user =
                    await userRepository.GetByIdAsync(request.UserId, cancellationToken) ??
                    throw new UserNotFoundExcpetion();
                await commentRepository.CreateAsync(mapper.Map(request, user), cancellationToken);
                return;
            }

            var content = mapper.Map(request.Content);
            var updated = comment.TryUpdate(request.UpdatedAt, request.IsDeleted, request.Version, content);
            if (updated)
            {
                if (comment.ShouldBeDeleted)
                {
                    await commentRepository.DeleteAsync(comment, cancellationToken);
                    return;
                }
                await commentRepository.UpdateAsync(comment, cancellationToken);
            }
        }
    }
}
