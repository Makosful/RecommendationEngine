using HotChocolate.Execution;
using Rytme.Recommendation.Engine.WebApi.Entities;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Payloads;
using Rytme.Recommendation.Engine.WebApi.Services.Interfaces;

namespace Rytme.Recommendation.Engine.WebApi.GraphQL;

public class Mutation
{
    public ArticleAddedPayload AddArticle(
        [Service] IArticleScoreService articleScoreService,
        [Service] ICategoryService categoryService,
        AddArticleInput input)
    {
        // Input validation
        if (input.Id < 1) throw new QueryException("Article ID is invalid.");

        IList<Category> categories;
        try
        {
            categories = categoryService.GetCategories(input.Categories);
        }
        catch (ArgumentException ex)
        {
            throw new QueryException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new QueryException(ex.Message);
        }

        var scores = new List<ArticleScore>();
        foreach (var categoryScore in input.Categories)
        {
            Category? score = null;
            foreach (var category in categories)
            {
                if (categoryScore.Id != category.Id) continue;
                score = category;
                break;
            }

            if (score is null) continue;
            var articleScore = new ArticleScore
            {
                ArticleId = input.Id,
                Category = score,
                Score = categoryScore.Score,
                IsAssigned = true
            };

            scores.Add(AddArticleScore(articleScoreService, articleScore));
        }

        return new ArticleAddedPayload
        {
            Id = input.Id,
            Scores = scores.Select(x => new CategoryScore
            {
                Id = x.Category.Id,
                Score = x.Score
            })
        };
    }

    private static ArticleScore AddArticleScore(
        IArticleScoreService articleScoreService,
        ArticleScore articleScore)
    {
        bool isSuccess;
        try
        {
            isSuccess = articleScoreService.AddScore(articleScore);
        }
        catch (Exception ex)
        {
            throw new QueryException(ex.Message);
        }

        if (!isSuccess) throw new QueryException("The article already exists in the system");

        return articleScore;
    }
}