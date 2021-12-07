using System.Threading;
using System.Threading.Tasks;
using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.GraphQL
{
    public class Query
    {
        public async Task<Article> GetArticle(CancellationToken token)
        {
            return new Article
            {
                Id = 12345,
                Name = "How to not to"
            };
        }
    }
}