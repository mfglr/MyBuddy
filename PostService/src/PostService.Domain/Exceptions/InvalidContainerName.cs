namespace PostService.Domain.Exceptions
{
    public class InvalidContainerName()
        : Exception($"Invalid container name!. The name of A media belongs to a post must be \"{Post.MediaContainerName}\"");
}
