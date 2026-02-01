namespace PostQueryService.Domain.UserDomain
{
    public record UserMedia(
        string ContainerName,
        string BlobName,
        MediaType Type,
        Metadata? Metadata,
        ModerationResult? ModerationResult,
        IEnumerable<Thumbnail> Thumbnails,
        bool IsDeleted,
        bool IsActive
    );
}
