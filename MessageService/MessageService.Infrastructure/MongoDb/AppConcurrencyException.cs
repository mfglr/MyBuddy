namespace MessageService.Infrastructure.MongoDb
{
    public class AppConcurrencyException() : Exception("Conflict detected.");
}
