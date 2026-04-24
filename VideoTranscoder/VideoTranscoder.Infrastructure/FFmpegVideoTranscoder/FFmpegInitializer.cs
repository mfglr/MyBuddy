using Xabe.FFmpeg;
using Xabe.FFmpeg.Downloader;

namespace VideoTranscoder.Infrastructure.FFmpegVideoTranscoder
{
    public class FFmpegInitializer
    {
        public async Task InitAsync()
        {
            var path = $"{AppContext.BaseDirectory}/FFmpeg";
            FFmpeg.SetExecutablesPath(path);
            await FFmpegDownloader.GetLatestVersion(FFmpegVersion.Official, path);
        }
    }
}
