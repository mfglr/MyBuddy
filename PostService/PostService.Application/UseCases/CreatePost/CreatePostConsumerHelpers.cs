using Microsoft.AspNetCore.Http;
using PostService.Domain;
using Shared.Objects;

namespace PostService.Application.UseCases.CreatePost
{
    internal static class CreatePostConsumerHelpers
    {

        public static IReadOnlyList<CreatePostResponse_Media> GenerateMedia(IReadOnlyList<MediaType> types, IReadOnlyList<string> blobNames)
        {
            List<CreatePostResponse_Media> medias = [];
            for (int i = 0; i < blobNames.Count; i++)
                medias.Add(new CreatePostResponse_Media(
                    Post.MediaContainerName,
                    blobNames.ElementAt(i),
                    types.ElementAt(i)
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