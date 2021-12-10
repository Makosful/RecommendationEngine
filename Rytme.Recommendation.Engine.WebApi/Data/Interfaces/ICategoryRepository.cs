using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.Data.Interfaces;

public interface ICategoryRepository
{
    IQueryable<Category> GetCategoryQuery();
}