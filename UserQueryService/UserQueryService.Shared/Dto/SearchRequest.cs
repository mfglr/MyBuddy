namespace UserQueryService.Shared.Dto
{
    public record SearchRequest(string Key, Guid? Cursor, int PageSize);
}
