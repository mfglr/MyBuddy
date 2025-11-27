namespace ContentModerator.Application
{
    public interface IImageFrameExtractor
    {
        Task ExtractAsync(string inputPath, string outputPath, double resulation, CancellationToken cancellationToken);
    }
}
