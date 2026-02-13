namespace PostLikeQueryService.Application
{
    public record PostLikeResponse_Metadata(
        double Width,
        double Height,
        double Duration
    );
    public record PostLikeResponse_ModerationResult(
        int Hate,
        int SelfHarm,
        int Sexual,
        int Violence
    );
    public record PostLikeResponse_Thumbnail(
        string BlobName,
        double Resolution,
        bool IsSquare
    );
    public record PostLikeResponse_Media(
        string ContainerName,
        string BlobName,
        PostLikeResponse_Metadata Metadata,
        PostLikeResponse_ModerationResult ModerationResult,
        IEnumerable<PostLikeResponse_Thumbnail> Thumbnails
    );
    public record PostLikeResponse(
        Guid UserId,
        string? Name,
        string UserName,
        PostLikeResponse_Media? Media,
        DateTime CreatedAt
    );
}
