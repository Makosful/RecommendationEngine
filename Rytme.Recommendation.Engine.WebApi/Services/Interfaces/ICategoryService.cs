using Rytme.Recommendation.Engine.WebApi.Entities;
using Rytme.Recommendation.Engine.WebApi.GraphQL.Inputs;

namespace Rytme.Recommendation.Engine.WebApi.Services.Interfaces;

public interface ICategoryService
{
    IList<Category> GetCategories(IList<AddArticleInput.CategoryScore> categoryIds);
}