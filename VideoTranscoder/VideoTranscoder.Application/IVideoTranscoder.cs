namespace VideoTranscoder.Application
{
    public interface IVideoTranscoder
    {
        Task Transcode(string inputPath, string outputPath, CancellationToken cancellationToken);
    }
}
