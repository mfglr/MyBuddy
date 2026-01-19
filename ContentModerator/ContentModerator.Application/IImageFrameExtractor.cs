namespace ContentModerator.Application
{
    public interface IImageFrameExtractor
    {
        Task<string> ExtractAsync(string inputPath, string tempPath, double resolution, CancellationToken cancellationToken);
    }
}
