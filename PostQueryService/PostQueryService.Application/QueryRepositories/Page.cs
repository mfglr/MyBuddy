namespace PostQueryService.Application.QueryRepositories
{
    public record Page(DateTime Cursor, int RecordsPerPage, bool IsDescending);
}
