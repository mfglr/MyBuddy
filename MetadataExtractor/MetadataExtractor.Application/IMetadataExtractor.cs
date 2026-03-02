using Shared.Events.SharedObjects;

namespace MetadataExtractor.Application
{
    public interface IMetadataExtractor
    {
        Task<Metadata> ExtractAsync(Stream input, CancellationToken cancellationToken);
    }
}
