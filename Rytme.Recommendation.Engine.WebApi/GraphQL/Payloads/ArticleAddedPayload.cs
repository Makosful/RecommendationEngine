using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.GraphQL.Payloads;

public class ArticleAddedPayload
{
    public long Id { get; set; }
    public IEnumerable<CategoryScore> Scores { get; set; }
}