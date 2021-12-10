using Rytme.Recommendation.Engine.WebApi.Data.Base;
using Rytme.Recommendation.Engine.WebApi.Data.Interfaces;
using Rytme.Recommendation.Engine.WebApi.Entities;

namespace Rytme.Recommendation.Engine.WebApi.Data;

public class CategoryRepository : NhRepository<Category>, ICategoryRepository
{
    public IQueryable<Category> GetCategoryQuery()
    {
        return Query();
    }
}