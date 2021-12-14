using Rytme.Recommendation.Core.Entity;

namespace Rytme.Recommendation.Core.Repositories.Interfaces;

public interface ICategoryRepository
{
    IQueryable<Category> GetCategoryQuery();
}