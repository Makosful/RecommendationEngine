using System;
using System.Collections.Generic;
using Rytme.Recommendation.Engine.WebApi.Entities;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;

namespace Rytme.Recommendation.Engine.WebApi.Data
{
    public class ArticleRepository : IArticleRepository
    {
        public IEnumerable<Article> GetAllArticles()
        {
            throw new NotImplementedException();
        }

        public Article GetArticles(long id)
        {
            throw new NotImplementedException();
        }

        public Article AddArticle(AddArticleInput input)
        {
            throw new NotImplementedException();
        }
    }
}