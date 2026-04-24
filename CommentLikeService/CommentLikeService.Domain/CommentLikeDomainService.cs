namespace CommentLikeService.Domain
{
    public class CommentLikeDomainService(ICommentLikeRepository repository)
    {
        public async Task<CommentLike> Like(CommentLikeId id, CancellationToken cancellationToken)
        {
            if (await repository.ExistAsync(id, cancellationToken))
                throw new CommentAlreadyLikedException();
            return new(id);
        }
    }
}
