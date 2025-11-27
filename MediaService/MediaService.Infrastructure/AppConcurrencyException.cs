namespace MediaService.Infrastructure
{
    public class AppConcurrencyException() : Exception("Conflict detected.");
}
