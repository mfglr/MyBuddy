namespace UserService.Domain
{
    public class InvalidMediaTypeException() : Exception("Only image media type is allowed for user profile media.");
}
