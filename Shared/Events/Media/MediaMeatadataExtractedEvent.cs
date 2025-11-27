namespace Shared.Events.Media
{
    public record MediaMeatadataExtractedEvent(Guid Id, double Width, double Height, double Duration);
}
