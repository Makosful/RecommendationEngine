using HotChocolate.Execution;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Payloads;
using Rytme.Recommendation.Engine.WebApi.Services.Interfaces;

namespace Rytme.Recommendation.Engine.WebApi.GraphQL;

public class Mutation
{
    private readonly IArticleService _service;

    public Mutation(IArticleService service)
    {
        _service = service;
    }

    public ArticleAddedPayload AddArticle(AddArticleInput input)
    {
        try
        {
            var article = _service.AddArticle(input);
            return new ArticleAddedPayload(article);
        }
        catch (ArgumentException ex)
        {
            throw new QueryException(ex.Message);
        }
    }
}