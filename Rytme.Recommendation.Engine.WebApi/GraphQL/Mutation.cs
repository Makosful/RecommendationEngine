using System;
using HotChocolate.Execution;
using Rytme.Recommendation.Engine.WebApi.Data;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Payloads;

namespace Rytme.Recommendation.Engine.WebApi.GraphQL
{
    public class Mutation
    {
        private readonly IArticleRepository _repository;

        public Mutation(IArticleRepository repository)
        {
            _repository = repository;
        }

        public ArticleAddedPayload AddArticle(AddArticleInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Name))
                throw new QueryException("Input is empty");

            try
            {
                var article = _repository.AddArticle(input);
                return new ArticleAddedPayload(article);
            }
            catch (ArgumentException ex)
            {
                throw new QueryException(ex.Message);
            }
        }
    }
}