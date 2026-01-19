namespace ContentModerator.Application
{
    public interface IVideoFrameExtractor
    {
        Task<IEnumerable<string>> ExtractAsync(string inputPath, string tempPath, double resulation, double fps, CancellationToken cancellationToken);
    }
}
