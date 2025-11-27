namespace MetadataExtractor.Application
{
    public record Metadata(double Width, double Height, double Duration);

    public interface IMetadataExtractor
    {
        Task<Metadata> Extract(string input, string tempPath, CancellationToken cancellationToken);
    }
}
