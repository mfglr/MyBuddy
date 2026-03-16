namespace CommentQueryService.Shared.Dto
{
    public record GetByParentIdRequest(Guid ParentId, Guid? Cursor, int PageSize);
}
