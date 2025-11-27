using ContentModerator.Application;
using Xabe.FFmpeg;

namespace ContentModerator.Infrastructure
{
    internal class ImageFrameExtractor : IImageFrameExtractor
    {
        public async Task ExtractAsync(string inputPath, string outputPath, double resulation, CancellationToken cancellationToken)
        {
            var scale = $"scale='if(gte(iw,ih),{resulation},-2)':'if(gte(ih,iw),{resulation},-2)'";

            await FFmpeg.Conversions.New()
                    .AddParameter($"-i \"{inputPath}\"")
                    .AddParameter($"-vf \"{scale}\"")
                    .SetOutput(outputPath)
                    .Start(cancellationToken);
        }
    }
}
