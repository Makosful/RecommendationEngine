using Rytme.Recommendation.Core.Entity;

namespace Rytme.Recommendation.WebApi.GraphQL.Payloads;

public class ArticleAddedPayload
{
    public long Id { get; set; }
    public IEnumerable<CategoryScore> Scores { get; set; }
}