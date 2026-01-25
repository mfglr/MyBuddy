namespace UserQueryService.Domain
{
    public class AppConcurrencyException() : Exception("Conflict detected!");
}
