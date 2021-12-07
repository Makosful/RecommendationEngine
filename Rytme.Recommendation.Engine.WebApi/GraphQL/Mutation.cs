using System.Threading;
using System.Threading.Tasks;
using Rytme.Recommendation.Engine.WebApi.Entities;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Payloads;

namespace Rytme.Recommendation.Engine.WebApi.GraphQL
{
    public class Mutation
    {
        public async Task<ArticleAddedPayload> AddArticle(AddArticleInput input, CancellationToken token)
        {
            Article article = new()
            {
                Id = 23456,
                Name = input.Name
            };

            return new ArticleAddedPayload(article);
        }
    }
}