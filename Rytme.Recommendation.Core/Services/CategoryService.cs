using Rytme.Recommendation.Core.Entity;
using Rytme.Recommendation.Core.Repositories.Interfaces;
using Rytme.Recommendation.Core.Services.Interfaces;

namespace Rytme.Recommendation.Core.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public IList<Category> GetCategories(IList<CategoryScore> categoryIds)
    {
        IList<Category> categories = new List<Category>();
        var queryable = _repository.GetCategoryQuery();

        foreach (var category in queryable)
        {
            var item = queryable.FirstOrDefault(x => x.Id == category.Id);
            if (item is null)
                throw new ArgumentException(""); // TODO
            categories.Add(item);
        }

        return categories;
    }
}