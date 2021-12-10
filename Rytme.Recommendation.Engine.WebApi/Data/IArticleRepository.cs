using Rytme.Recommendation.Engine.WebApi.Entities;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;

namespace Rytme.Recommendation.Engine.WebApi.Data;

public interface IArticleRepository
{
    public IEnumerable<Article> GetAllArticles();

    public Article GetArticle(long id);

    public bool AddArticle(AddArticleInput input);
}