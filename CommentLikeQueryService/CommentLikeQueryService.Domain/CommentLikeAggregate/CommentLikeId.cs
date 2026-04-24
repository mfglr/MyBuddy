namespace CommentLikeQueryService.Domain.CommentLikeAggregate
{
    public record CommentLikeId(Guid CommentId, Guid SequenceId, Guid UserId);
}
