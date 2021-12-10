using Rytme.Recommendation.Engine.WebApi.Entities;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;

namespace Rytme.Recommendation.Engine.WebApi.Data;

public class ArticleRepository : NhRepository<Article>, IArticleRepository
{
    public IEnumerable<Article> GetAllArticles()
    {
        throw new NotImplementedException();
    }

    public Article GetArticle(long id)
    {
        throw new NotImplementedException();
    }

    public bool AddArticle(AddArticleInput input)
    {
        throw new NotImplementedException();
    }
}