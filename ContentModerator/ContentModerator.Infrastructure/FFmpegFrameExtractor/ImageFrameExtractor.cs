using ContentModerator.Application;
using Xabe.FFmpeg;

namespace ContentModerator.Infrastructure.FFmpegFrameExtractor
{
    internal class ImageFrameExtractor : IImageFrameExtractor
    {
        public async Task<string> ExtractAsync(string inputPath, string tempPath, double resolution, CancellationToken cancellationToken)
        {
            var info = await FFmpeg.GetMediaInfo(inputPath, cancellationToken);
            var vStream = info.VideoStreams.First();
            bool isScaleDownRequired = vStream.Height > vStream.Width ? vStream.Height > resolution : vStream.Height > resolution;

            var conversion = FFmpeg.Conversions.New().AddParameter($"-i \"{inputPath}\"");
            if (isScaleDownRequired)
            {
                var scale = $"scale='if(gt(iw,ih),{resolution},-2)':'if(gt(ih,iw),{resolution},-2)'";
                conversion.AddParameter($"-vf \"{scale}\"");
            }
            await conversion
                .AddParameter("-loglevel error")
                .SetOutput($"{tempPath}.jpeg")
                .Start(cancellationToken);

            return $"{tempPath}.jpeg";
        }
    }
}
