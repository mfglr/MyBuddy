namespace Shared
{
    public record PaginationKey<T>(T? Key, bool IsDescending);
}
