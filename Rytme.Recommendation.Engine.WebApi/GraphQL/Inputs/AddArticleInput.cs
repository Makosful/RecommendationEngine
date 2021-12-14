using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;

public class AddArticleInput
{
    public AddArticleInput()
    {
        Categories = new List<CategoryScore>();
    }

    public long Id { get; set; }

    public IList<CategoryScore> Categories { get; set; }
}