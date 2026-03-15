namespace PostLikeQueryService.Shared.Dto
{
    public record GetByPostIdRequest(Guid PostId, Guid? Cursor, int PageSize);
}
