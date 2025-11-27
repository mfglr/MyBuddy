using ContentModerator.Application;
using Xabe.FFmpeg;

namespace ContentModerator.Infrastructure
{
    internal class VideoFrameExtractor : IVideoFrameExtractor
    {
        public async Task<IEnumerable<string>> ExtractAsync(string inputPath, string outputPath, double resulation, double fps, CancellationToken cancellationToken)
        {
            var info = await FFmpeg.GetMediaInfo(inputPath, cancellationToken);
            var duration = (int)info.Duration.TotalSeconds;
            var vStream = info.VideoStreams.First();
            bool isScaleDownRequired = vStream.Height > vStream.Width ? vStream.Height > resulation : vStream.Height > resulation;
            var scale = $"scale='if(gt(iw,ih),{resulation},-2)':'if(gt(ih,iw),{resulation},-2)'";

            var filter = $"fps={fps}";
            if (isScaleDownRequired)
                filter = $"{filter},{scale}";

            await FFmpeg.Conversions.New()
                .AddParameter($"-i \"{inputPath}\"")
                .AddParameter($"-vf \"{filter}\"")
                .SetOutput($"{outputPath}_%d.jpg")
                .Start(cancellationToken);

            int lengthOfFrames = (int)(duration * fps);
            var outputPaths = new string[lengthOfFrames];

            for (int i = 1; i <= lengthOfFrames; i++)
                outputPaths[i - 1] = $"{outputPath}_{i}.jpg";

            return outputPaths;
        }
    }
}
