using PostQueryService.Domain;

namespace ElasticSearch.IntegreationTests.EqualityComparers
{
    internal static class MediaListEqualityComparer
    {
        public static bool IsEqual(IEnumerable<PostQueryMedia> x, IEnumerable<PostQueryMedia> y)
        {
            if(x == y) return true;
            if (x.Count() != y.Count()) return false;

            var ex = x.GetEnumerator();
            var ey = y.GetEnumerator();

            while (ex.MoveNext())
                if (ex.Current != ey.Current)
                    return false;

            return true;
        }
    }
}
