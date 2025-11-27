namespace ContentModerator.Application
{
    public interface IFrameExtractor
    {
        Task ExstractAsync(string inputPath, string outputPath, CancellationToken cancellationToken, double? positionMs = null, double resulation = 256);
    }
}
