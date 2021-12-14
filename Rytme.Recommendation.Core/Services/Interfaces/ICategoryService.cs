using Rytme.Recommendation.Core.Entity;

namespace Rytme.Recommendation.Core.Services.Interfaces;

public interface ICategoryService
{
    IList<Category> GetCategories(IList<CategoryScore> categoryIds);
}