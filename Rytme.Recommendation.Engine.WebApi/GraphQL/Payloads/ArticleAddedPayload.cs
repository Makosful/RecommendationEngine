namespace Rytme.Recommendation.Engine.WebApi.GraphQL.Payloads;

public class ArticleAddedPayload
{
    public long Id { get; set; }
    public IEnumerable<CategoryScore> Scores { get; set; }

    public class CategoryScore
    {
        public long Id { get; set; }
        public float Score { get; set; }
    }
}