using CommentLikeQueryService.Domain.CommentLikeAggregate;
using CommentLikeQueryService.Domain.UserAggregate;
using MediatR;

namespace CommentLikeQueryService.Application.UseCases.CreateCommentLike
{
    internal class CreateCommentLikeHandler(
        CreateCommentLikeMapper mapper,
        ICommentLikeRepository commentLikeRepository,
        IUserRepository userRepository
    ) : IRequestHandler<CreateCommentLikeRequest>
    {
        public async Task Handle(CreateCommentLikeRequest request, CancellationToken cancellationToken)
        {
            var user = 
                await userRepository.GetByIdAsync(request.UserId, cancellationToken) ??
                throw new UserNotFoundException();

            var comment = mapper.Map(request, user);
            await commentLikeRepository.CreateAsync(comment, cancellationToken);
        }
    }
}
