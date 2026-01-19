using ContentModerator.Application;
using Xabe.FFmpeg;

namespace ContentModerator.Infrastructure.FFmpegFrameExtractor
{
    internal class VideoFrameExtractor : IVideoFrameExtractor
    {
        public async Task<IEnumerable<string>> ExtractAsync(string inputPath, string tempPath, double resolution, double fps, CancellationToken cancellationToken)
        {
            var info = await FFmpeg.GetMediaInfo(inputPath, cancellationToken);
            var duration = (int)info.Duration.TotalSeconds;
            var vStream = info.VideoStreams.First();
            bool isScaleDownRequired = vStream.Height > vStream.Width ? vStream.Height > resolution : vStream.Height > resolution;

            var filter = $"fps={fps}";
            if (isScaleDownRequired)
            {
                var scale = $"scale='if(gt(iw,ih),{resolution},-2)':'if(gt(ih,iw),{resolution},-2)'";
                filter = $"{filter},{scale}";
            }

            await FFmpeg.Conversions.New()
                .AddParameter($"-i \"{inputPath}\"")
                .AddParameter($"-vf \"{filter}\"")
                .AddParameter("-loglevel error")
                .SetOutput($"{tempPath}_%d.jpeg")
                .Start(cancellationToken);

            int lengthOfFrames = (int)(duration * fps);
            var outputPaths = new string[lengthOfFrames];

            for (int i = 1; i <= lengthOfFrames; i++)
                outputPaths[i - 1] = $"{tempPath}_{i}.jpeg";

            return outputPaths;
        }
    }
}
