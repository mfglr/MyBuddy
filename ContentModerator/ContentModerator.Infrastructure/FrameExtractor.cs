using ContentModerator.Application;
using Xabe.FFmpeg;

namespace ContentModerator.Infrastructure
{
    internal class FrameExtractor : IFrameExtractor
    {
        public async Task ExstractAsync(string inputPath, string outputPath, CancellationToken cancellationToken, double? positionMs, double resulation)
        {
            var info = await FFmpeg.GetMediaInfo(inputPath, cancellationToken);
            var vStream = info.VideoStreams.First();
            bool isScaleDownRequired = vStream.Height > vStream.Width ? vStream.Height > resulation : vStream.Height > resulation;
            var scale = $"scale='if(gt(iw,ih),{resulation},-2)':'if(gt(ih,iw),{resulation},-2)'";

            var conversation = FFmpeg.Conversions.New();
            if (positionMs != null)
                conversation.AddParameter($"-ss {positionMs}");
            
            conversation
                .AddParameter($"-i \"{inputPath}\"")
                .AddParameter("-frames:v 1");

            if (isScaleDownRequired)
                conversation.AddParameter($"-vf {scale}");

            conversation.SetOutput(outputPath);

            await conversation.Start(cancellationToken);
        }
    }
}
