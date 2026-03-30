using Elastic.Clients.Elasticsearch;
using PostQueryService.Domain;

namespace PostQueryService.Infrastructure.ElastichSearch
{
    internal class VersionMapper
    {
        public PostProjection Map(GetResponse<PostProjection> response)
        {
            var post = response.Source!;
            post.Version = new Version(response.PrimaryTerm, response.SeqNo);
            return post;
        }

        public IReadOnlyCollection<PostProjection> Map(SearchResponse<PostProjection> response)
        {
            var ed = response.Documents.GetEnumerator();
            var eh = response.Hits.GetEnumerator();
            while(ed.MoveNext())
            {
                eh.MoveNext();
                ed.Current.Version = new Version(eh.Current.PrimaryTerm, eh.Current.SeqNo);
            }
            return response.Documents;
        }
    }
}
