using Rytme.Recommendation.WebApi.GraphQL.Payloads;

namespace Rytme.Recommendation.WebApi.GraphQL;

public class Query
{
    public ArticleAddedPayload Test()
    {
        return new ArticleAddedPayload
        {
            Id = 123456789,
            // Scores = new[]
            // {
                // new CategoryScore
                // {
                    // Id = 987654321,
                    // Score = 5.9f
                // }
            // }
        };
    }
}