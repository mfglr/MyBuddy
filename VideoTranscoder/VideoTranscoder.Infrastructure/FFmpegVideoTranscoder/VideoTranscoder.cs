using VideoTranscoder.Application;
using Xabe.FFmpeg;

namespace VideoTranscoder.Infrastructure.FFmpegVideoTranscoder
{
    internal class VideoTranscoder : IVideoTranscoder
    {
        public async Task Transcode(string inputPath, string outputPath, double resolution, CancellationToken cancellationToken)
        {
            var mediaInfo = await FFmpeg.GetMediaInfo(inputPath, cancellationToken);
            var vStream = mediaInfo.VideoStreams.First();
            bool isScaleDownRequired = vStream.Height > vStream.Width ? vStream.Height > resolution : vStream.Width > resolution;
            var fps = vStream.Framerate;

            IConversion conversation = FFmpeg.Conversions.New().AddParameter($"-i \"{inputPath}\"");

            if (isScaleDownRequired)
            {
                var scale = $"scale='if(gt(iw,ih),{resolution},-2)':'if(gt(ih,iw),{resolution},-2)'";
                conversation.AddParameter($"-vf {scale}");
            }

            if (!double.IsNaN(fps) && fps > 30)
                conversation.AddParameter($"-r 30");

            conversation
                .AddParameter("-c:v libx265")
                .AddParameter("-c:a aac")
                .AddParameter("-crf 28")
                .AddParameter("-preset medium")
                .AddParameter($"-movflags +faststart")
                .SetOutput(outputPath);

            await conversation.Start(cancellationToken);
        }
    }
}
