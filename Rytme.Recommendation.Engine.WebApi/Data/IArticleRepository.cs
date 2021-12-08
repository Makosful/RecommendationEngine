using System.Collections.Generic;
using Rytme.Recommendation.Engine.WebApi.Entities;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;

namespace Rytme.Recommendation.Engine.WebApi.Data
{
    public interface IArticleRepository
    {
        public IEnumerable<Article> GetAllArticles();

        public Article GetArticles(long id);

        public Article AddArticle(AddArticleInput input);
    }
}