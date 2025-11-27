using Xabe.FFmpeg;

namespace MetadataExtractor.Infrastructure
{
    public static class FFmpegConfigration
    {
        public static void Configure() =>
                FFmpeg.SetExecutablesPath($"{AppContext.BaseDirectory}/FFmpeg");
    }
}
