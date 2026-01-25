namespace UserService.Infrastructure.Mongo
{
    public class AppConcurrencyException() : Exception("Conflict detected.");
}
