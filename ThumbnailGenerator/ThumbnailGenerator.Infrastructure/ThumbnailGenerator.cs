using ThumbnailGenerator.Application;
using Xabe.FFmpeg;

namespace ThumbnailGenerator.Infrastructure
{
    internal class ThumbnailGenerator : IThumbnailGenerator
    {
        public async Task GenerateAsync(string input, string output, double resulation, bool isSquare, CancellationToken cancellationToken)
        {
            string filter;
            if (isSquare)
                filter = $"crop='if(gt(iw,ih),ih,iw):if(gt(iw,ih),ih,iw):(iw-if(gt(iw,ih),ih,iw))/2:(ih-if(gt(iw,ih),ih,iw))/2',scale='if(gt(iw,ih),if(gt({resulation},ih),ih,{resulation}),if(gt({resulation},iw),iw,{resulation})):if(gt(iw,ih),if(gt({resulation},ih),ih,{resulation}),if(gt({resulation},iw),iw,{resulation}))'";
            else
                filter = $"scale='if(gt(iw,ih),if(gt({resulation},iw),iw,{resulation}),-2)':'if(gt(ih,iw),if(gt({resulation},ih),ih,{resulation}),-2)'";

            await FFmpeg.Conversions.New()
                .AddParameter($"-i \"{input}\"")
                .AddParameter($"-vf {filter}")
                .AddParameter("-vframes 1")
                .SetOutput(output)
                .Start(cancellationToken);
        }
    }
}
