namespace CommentService.Application.UseCases.CreateComment
{
    public record CreateCommentRequest(Guid PostId, Guid? ParentId, Guid? RepliedId, string Content);
}
