using Media.Models;
using PostService.Domain;

namespace PostService.Application.UseCases.CreatePost
{
    internal class MediaGenerator(MediaInstructionCreator mediaInstructionCreator)
    {
        public IEnumerable<PostMedia> Generate(IEnumerable<MediaType> types, IEnumerable<string> blobNames)
        {
            if (types.Count() != blobNames.Count())
                throw new Exception("");

            List<PostMedia> medias = [];
            var te = types.GetEnumerator();
            var be = blobNames.GetEnumerator();
            while(te.MoveNext() && be.MoveNext())
                medias.Add(
                    new PostMedia(
                        Post.MediaContainerName,
                        be.Current,
                        MediaProcessingContext.Create(te.Current,mediaInstructionCreator.Create())
                    )
                );
            return medias;
        }
    }
}