namespace MediaService.Application.UseCases.SetMediaMetadata
{
    public record SetMediaMetadataRequest(Guid Id, double Width, double Height, double Duration);
}
