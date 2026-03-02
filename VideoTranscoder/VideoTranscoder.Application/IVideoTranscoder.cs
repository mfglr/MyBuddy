namespace VideoTranscoder.Application
{
    public interface IVideoTranscoder
    {
        Task Transcode(string inputPath, string outputPath, double resolution, CancellationToken cancellationToken);
    }
}
