using Microsoft.AspNetCore.Http;

namespace UserService.Application.UseCases.CreateMedia
{
    internal class MediaTypeValidator
    {
        public void Validate(IFormFile media)
        {
            if (!media.ContentType.StartsWith("image"))
                throw new Exception("Invalid media type.");
        }
    }
}
