using HotChocolate.Execution;
using Rytme.Recommendation.Engine.WebApi.Entities;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Payloads;
using Rytme.Recommendation.Engine.WebApi.Services.Interfaces;

namespace Rytme.Recommendation.Engine.WebApi.GraphQL;

public class Mutation
{
    // private readonly IArticleScoreService _articleScoreService;
    // private readonly ICategoryService _categoryService;

    public ArticleAddedPayload AddArticle(
        [Service] IArticleScoreService articleScoreService,
        [Service] ICategoryService categoryService,
        AddArticleInput input)
    {
        IList<Category> categories1;
        try
        {
            categories1 = categoryService.GetCategories(input.Categories);
        }
        catch (ArgumentException ex)
        {
            throw new QueryException(ex.Message);
        }

        var categories = categories1;
        IList<ArticleScore> scores = new List<ArticleScore>();

        foreach (var category in categories)
        {
            var articleScore = new ArticleScore
            {
                // TODO
            };
            var isSuccess = articleScoreService.AddScore(articleScore);
            if (!isSuccess) throw new QueryException("I do not even know");

            scores.Add(articleScore);
        }

        return new ArticleAddedPayload
        {
            Id = input.Id,
            Scores = scores.Select(x => new ArticleAddedPayload.CategoryScore
            {
                Id = x.Category.Id,
                Score = x.Score
            })
        };
    }
}