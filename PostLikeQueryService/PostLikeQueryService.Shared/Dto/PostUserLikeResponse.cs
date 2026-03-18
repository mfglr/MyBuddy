namespace PostLikeQueryService.Shared.Dto
{
    public record PostUserLikeResponse(
        Guid SequenceId,
        DateTime CreatedAt,
        Guid UserId,
        string UserName,
        string? Name,
        Media.Models.Media? Media
    );
}
