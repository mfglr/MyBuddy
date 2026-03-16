namespace CommentQueryService.Shared.Dto
{
    public record GetByParentId(Guid ParentId, Guid? Cursor, int PageSize);
}
