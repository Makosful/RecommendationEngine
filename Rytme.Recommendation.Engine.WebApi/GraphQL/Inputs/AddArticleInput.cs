namespace Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;

public class AddArticleInput
{
    public AddArticleInput()
    {
        Categories = new List<CategoryScore>();
    }

    public long Id { get; set; }

    public IList<CategoryScore> Categories { get; set; }

    public class CategoryScore
    {
        public long Id { get; set; }
        public float Score { get; set; }
    }
}