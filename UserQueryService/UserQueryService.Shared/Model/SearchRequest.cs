namespace UserQueryService.Shared.Model
{
    public record SearchRequest(string Key, Guid? Cursor, int PageSize);
}
