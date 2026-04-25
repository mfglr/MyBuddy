namespace PostLikeService.Domain
{
    public class PostLikeDomainService(IPostLikeRepository repository)
    {
        public async Task<PostLike> Like(PostLikeId id, CancellationToken cancellationToken)
        {
            if (await repository.ExistAsync(id, cancellationToken))
                throw new PostAlreadyLikedException();
            return new(id);
        }
    }
}
