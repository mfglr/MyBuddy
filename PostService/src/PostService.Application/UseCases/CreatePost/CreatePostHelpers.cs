using Media.Models;
using Microsoft.AspNetCore.Http;
using PostService.Domain;

namespace PostService.Application.UseCases.CreatePost
{
    internal static class CreatePostHelpers
    {
        public static IReadOnlyList<Media.Models.Media> GenerateMedia(IReadOnlyList<MediaType> types, IReadOnlyList<string> blobNames)
        {
            List<Media.Models.Media> medias = [];
            for (int i = 0; i < blobNames.Count; i++)
                medias.Add(Media.Models.Media.Create(
                    Post.MediaContainerName,
                    blobNames.ElementAt(i),
                    types.ElementAt(i),
                    MediaInstructionCreator.Create()
                ));
            return medias;
        }

        public static IReadOnlyList<MediaType> GetMediaTypes(IFormFileCollection media) =>
            [
                .. media
                    .Select(x =>
                        {
                            if (x.ContentType.StartsWith("image"))
                                return MediaType.Image;
                            else if (x.ContentType.StartsWith("video"))
                                return MediaType.Video;
                            throw new Exception("Invalid media type.");
                        }
                    )
            ];
    }
}