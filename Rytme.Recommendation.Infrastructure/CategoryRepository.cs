using Rytme.Recommendation.Core.Entity;
using Rytme.Recommendation.Core.Repositories.Interfaces;
using Rytme.Recommendation.Infrastructure.Base;

namespace Rytme.Recommendation.Infrastructure;

public class CategoryRepository : NhRepository<Category>, ICategoryRepository
{
    public IQueryable<Category> GetCategoryQuery()
    {
        return Query();
    }
}