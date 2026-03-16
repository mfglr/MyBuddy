namespace CommentQueryService.Shared.Dto
{
    public record GetByPostIdRequest(Guid PostId, Guid? Cursor, int PageSize);
}
