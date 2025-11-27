namespace Shared.Events.Media
{
    public record MediaThumbnailGeneratedEvent(Guid Id, string BlobName, double Resulation, bool IsSquare);
}
