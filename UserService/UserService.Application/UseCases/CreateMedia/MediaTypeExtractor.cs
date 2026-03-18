using Media.Models;
using Microsoft.AspNetCore.Http;

namespace UserService.Application.UseCases.CreateMedia
{
    internal class MediaTypeExtractor
    {
        public MediaType Extract(IFormFile media)
        {
            if (!media.ContentType.StartsWith("image"))
                throw new Exception("Invalid media type.");

            return MediaType.Image;
        }
    }
}
