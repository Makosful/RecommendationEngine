using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.Services.Interfaces;

public interface ICategoryService
{
    IList<Category> GetCategories(IList<CategoryScore> categoryIds);
}