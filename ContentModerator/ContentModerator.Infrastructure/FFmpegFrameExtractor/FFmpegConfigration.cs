using Xabe.FFmpeg;

namespace ContentModerator.Infrastructure.FFmpegFrameExtractor
{
    internal static class FFmpegConfigration
    {
        public static void Configure() =>
                FFmpeg.SetExecutablesPath($"{AppContext.BaseDirectory}/FFmpeg");
    }
}
