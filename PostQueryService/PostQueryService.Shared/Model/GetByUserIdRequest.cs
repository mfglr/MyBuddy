namespace PostQueryService.Shared.Model
{
    public record GetByUserIdRequest(Guid UserId, Guid? Cursor, int PageSize);
}
