using PostQueryService.Application.QueryRepositories;
using PostQueryService.Domain.PostDomain;

namespace PostQueryService.Infrastructure.MsSql.QuerRepositories
{
    internal static class ToPageExtention
    {
        public static IQueryable<Post> ToPage(this IQueryable<Post> query, Page page) =>
            page.IsDescending
                ? query
                    .Where(x => x.CreatedAt < page.Cursor)
                    .OrderByDescending(x => x.CreatedAt)
                    .Take(page.RecordsPerPage)
                : query
                    .Where(x => x.CreatedAt > page.Cursor)
                    .OrderBy(x => x.CreatedAt)
                    .Take(page.RecordsPerPage);
    }
}
