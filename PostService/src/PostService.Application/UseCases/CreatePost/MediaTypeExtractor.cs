using Media.Models;
using Microsoft.AspNetCore.Http;

namespace PostService.Application.UseCases.CreatePost
{
    internal class MediaTypeExtractor
    {
        public IEnumerable<MediaType> GetMediaTypes(IFormFileCollection media) =>
            media
                .Select(x =>
                {
                    if (x.ContentType.StartsWith("image"))
                        return MediaType.Image;
                    else if (x.ContentType.StartsWith("video"))
                        return MediaType.Video;
                    throw new Exception("Invalid media type.");
                });
    }
}
