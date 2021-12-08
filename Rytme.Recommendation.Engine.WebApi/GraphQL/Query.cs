using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rytme.Recommendation.Engine.WebApi.Data;
using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.GraphQL
{
    public class Query
    {
        private readonly IArticleRepository _repository;

        public Query(IArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Article>> GetArticles(CancellationToken token)
        {
            Console.WriteLine(token);
            return new List<Article>
            {
                new()
                {
                    Id = 123456789,
                    Title = "How to Not to"
                },
                new()
                {
                    Id = 234567891,
                    Title = "12 Rules for Life"
                }
            };
        }
    }
}